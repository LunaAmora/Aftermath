using UnityEngine;

namespace Aftermath
{
    public class EnumNamedListAttribute : PropertyAttribute
    {
        public string[] Names;
        public EnumNamedListAttribute(System.Type namesEnumType)
        {
            Names = System.Enum.GetNames(namesEnumType);
        }
    }
}
