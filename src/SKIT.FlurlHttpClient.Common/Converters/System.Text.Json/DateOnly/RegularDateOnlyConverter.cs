#if NET5_0_OR_GREATER
namespace System.Text.Json.Converters.Common
{
    public sealed class RegularDateOnlyConverter : FormattedDateOnlyConverterBase
    {
        protected override string FormatString
        {
            get { return "yyyy-MM-dd"; }
        }
    }
}
#endif
