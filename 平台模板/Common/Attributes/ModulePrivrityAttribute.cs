namespace Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ModulePriorityAttribute : Attribute
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// 模块名称
        /// </summary>

        public string ModelName { get; }

        /// <summary>
        /// 描述
        /// </summary>

        public string Description { get; } = "按钮";

        /// <summary>
        /// 列表上优先级
        /// </summary>
        public int Priority { get; } = 0;

        public string Icon { get; set; } = "";
        public ModulePriorityAttribute(int priority, string displayName, string modelName, string description = "")
        {
            Priority = priority;

            DisplayName = displayName;

            ModelName = modelName;
            Description = description;
        }
    }
}
