﻿using System.Collections.Generic;

namespace INFNET_F.C._API.Models
{
    public class Estadio
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public List<Partida> Partidas { get; set; }

    }
}