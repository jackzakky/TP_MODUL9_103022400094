class Program
{
    static void Main(string[] args)
    {
        CovidConfig covidConfig = new CovidConfig();
        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.config.satuan_suhu}");
        double suhuInput = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman?");
        int hariInput = Convert.ToInt32(Console.ReadLine()); 
        bool kondisiSuhu = false;

        if (covidConfig.config.satuan_suhu == "celcius")
        {
            
            if (suhuInput >= 36.5 && suhuInput <= 37.5) kondisiSuhu = true;
        }
        else if (covidConfig.config.satuan_suhu == "fahrenheit")
        {
            if (suhuInput >= 97.7 && suhuInput <= 99.5) kondisiSuhu = true;
        }

        bool kondisiHari = hariInput < covidConfig.config.batas_hari_deman;
        if (kondisiSuhu && kondisiHari)
        {
            Console.WriteLine("\n" + covidConfig.config.pesan_diterima);
        }
        else
        {
            Console.WriteLine("\n" + covidConfig.config.pesan_ditolak);
        }
    }
}