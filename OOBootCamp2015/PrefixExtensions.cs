namespace OOBootCamp2015
{
    public static class PrefixExtensions
    {
        public static string Prefix(this int prefixCount)
        {
            string prefix = "";
            for (int i = 0; i < prefixCount; i++)
            {
                prefix += "    ";
            }
            return prefix;
        }
 
    }
}