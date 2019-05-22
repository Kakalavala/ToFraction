public string ToFraction(double dec = 0)
{
    string sd = dec.ToString();

    if ((dec * 10) % 1 == 0)
    {
        double gcd = GetGCD(dec * 10, 10);
        double n = (dec * 10) / gcd;
        double d = 10 / gcd;

        return String.Format("{0}/{1}", n, d);
    }

    if (sd.IndexOf('.') != -1)
    {
        if (sd.Length - (sd.IndexOf('.') + 1) > 6)
            dec = double.Parse(dec.ToString("0.000000"));

        double c = dec.ToString().Length - (dec.ToString().IndexOf('.') + 1);
        double gcd = GetGCD(Math.Round((dec * (Math.Pow(10, c))) - dec), (Math.Pow(10, c)) - 1);
        double n = Math.Round(Math.Round((dec * (Math.Pow(10, c))) - dec) / gcd);
        double d = Math.Round(((Math.Pow(10, c)) - 1) / gcd);

        return String.Format("{0}/{1}", n, d);
    }
    else return dec.ToString();
}

double GetGCD(double n, double d)
{
    double num = (n < d) ? n : d;
    double den = (n < d) ? d : n;
    double rem = num;
    double lastRem = num;

    while (true)
    {
        lastRem = rem;
        rem = den % num;

        if (rem == 0)
            break;

        den = num;
        num = rem;
    }

    return lastRem;
}