namespace Lms.CoreLayer.Extensions;

public static  class ByteExtensions
{
    public static string ByteToString(this byte[] byteItem)
    {
        return Convert.ToBase64String(byteItem);
    }

    public static byte[] ToByte(this string stringItem)
    {
        return Convert.FromBase64String(stringItem);
    }
}
