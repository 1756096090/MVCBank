﻿namespace MVCBank.Models
{
    public class Transferencia
    {
        public int IdAccountSender { get; set; }
        public int IdAccountReceiver { get; set; }
        public float Amount { get; set; }
        //Modificar los cambios después
        public DateTime Time { get; set; }
    }
}
