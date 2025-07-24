using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xunit.Sdk;

namespace Xunit
{

    [Serializable]
    public class AssumptionFailedException : XunitException
    {
        public override string Message => _message;
        public override string StackTrace => _stackTrace;

        private readonly string _message;
        private readonly string _stackTrace;

        public AssumptionFailedException(string message) : base(message)
        {
            _stackTrace = CreateStackTrace();
            _message = base.Message + Environment.NewLine + _stackTrace;
        }

        public AssumptionFailedException(string message, Exception inner) : base(message, inner)
        {
            _stackTrace = CreateStackTrace();
            _message = base.Message + Environment.NewLine + _stackTrace;
        }

        private string CreateStackTrace()
        {
            var fullTrace = new StackTrace(true);
            var frames = fullTrace.GetFrames() ?? Array.Empty<StackFrame>();

            var enumeratedFrames = frames.Select((frame, idx) => new { idx, frame });
            var firstFrameNotFromThisAssembly = enumeratedFrames
                .FirstOrDefault(x => x.frame.GetMethod().DeclaringType.Assembly != typeof(Assume).Assembly);
            var skipFrames = firstFrameNotFromThisAssembly?.idx ?? 0;

            StackTrace? result = null;
            if (skipFrames == 0)
            {
                result = new StackTrace(skipFrames, true);
            }
            else
            {
                var frame = fullTrace.GetFrame(firstFrameNotFromThisAssembly!.idx);
                result = new StackTrace(frame);
            }

            return result.ToString();
        }
    }
}
