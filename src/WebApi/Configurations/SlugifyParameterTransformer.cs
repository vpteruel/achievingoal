using System.Text.RegularExpressions;

namespace Acl.Configurations
{
    public partial class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value) =>
            value == null ? string.Empty : MyRegex().Replace(value.ToString(), "$1-$2").ToLower();

        [GeneratedRegex("([a-z])([A-Z])")]
        private static partial Regex MyRegex();
    }
}