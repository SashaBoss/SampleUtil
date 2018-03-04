using System;

namespace SampleUtil
{
    internal class ActionProcessorFactory
    {
        public IActionProcessor GetProcessor(ActionType type)
        {
            switch (type)
            {
                case ActionType.All:
                    return new AllProcessor();
                case ActionType.Cpp:
                    return new CppProcessor();
                case ActionType.Reversed1:
                    return new Reversed1Processor();
                case ActionType.Reversed2:
                    return new Reversed2Processor();
                default:
                    throw new Exception("Not supported action" + type);
            }
        }
    }
}