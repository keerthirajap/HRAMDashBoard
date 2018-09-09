using log4net;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting
{
    [Serializable]
    public class Log4NetAttribute : OnMethodBoundaryAspect
    {
      
        public override void OnEntry(MethodExecutionArgs args)
        {
            ILog log = LogManager.GetLogger(args.Method.DeclaringType.UnderlyingSystemType);

        

        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ILog log = LogManager.GetLogger(args.Method.DeclaringType.UnderlyingSystemType);

           

        }

        public override void OnException(MethodExecutionArgs args)
        {
            ILog log = LogManager.GetLogger(args.Method.DeclaringType.UnderlyingSystemType);
            log.ErrorFormat("Exception {0} in {1}", args.Exception, args.Method);

            // args.FlowBehavior = FlowBehavior.Continue;
        }
        static string DisplayObjectInfo(MethodExecutionArgs args)
        {
            StringBuilder sb = new StringBuilder();
            Type type = args.Arguments.GetType();
            sb.Append("Method " + args.Method.Name);
            sb.Append("\r\nArguments:");
            FieldInfo[] fi = type.GetFields();

            if (fi.Length > 0)
            {
                foreach (FieldInfo f in fi)
                {
                    sb.Append("\r\n " + f + " = " + f.GetValue(args.Arguments));
                }
            }
            else
                sb.Append("\r\n None");

            return sb.ToString();
        }
    }
}
