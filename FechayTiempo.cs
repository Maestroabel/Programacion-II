namespace Examen_Final_Prog_II
{
    class FechayTiempo
    {
        public string Tiempo;
        public long Signo;

        public FechayTiempo(string tiempo, long signo)
           => (Tiempo, Signo) = (tiempo, signo);

        public static long FechayTiempoEntrada(FechayTiempo fechayTiempo)
        {
            fechayTiempo.Tiempo = fechayTiempo.Tiempo.Replace('-', ' ');
            fechayTiempo.Tiempo = fechayTiempo.Tiempo.Replace('T', ' ');
            fechayTiempo.Tiempo = fechayTiempo.Tiempo.Replace(':', ' ');
            fechayTiempo.Tiempo = fechayTiempo.Tiempo.Replace('.', ' ');
            fechayTiempo.Tiempo = fechayTiempo.Tiempo.Replace('+', ' ');

            string[] tiempo = fechayTiempo.Tiempo.Split(" ");

            long[] TNumero = new long[tiempo.Length];

            for (int i = 0; i < tiempo.Length; i++)
            {
                TNumero[i] = long.Parse(tiempo[i]);
            }

            if (fechayTiempo.Signo < 0)
                fechayTiempo.Signo = 0;
            else
                fechayTiempo.Signo = 1;

            long tiempoBi = TNumero[0] << 4;
            tiempoBi = (tiempoBi | TNumero[1]) << 5;
            tiempoBi = (tiempoBi | TNumero[2]) << 5;
            tiempoBi = (tiempoBi | TNumero[3]) << 6;
            tiempoBi = (tiempoBi | TNumero[4]) << 6;
            tiempoBi = (tiempoBi | TNumero[5]) << 10;
            tiempoBi = (tiempoBi | TNumero[6]) << 1;
            tiempoBi = (tiempoBi | fechayTiempo.Signo) << 5;
            tiempoBi = (tiempoBi | TNumero[7]) << 6;
            tiempoBi = (tiempoBi | TNumero[8]);

            return tiempoBi;
        }
    }
}
