using System;
using DIO.Series.Interfaces;
using System.Collections.Generic;

namespace DIO.Series
{
    public class SeriesRepositorio : IRepositorio<Serie>

    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        

        }

        public void Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public void Insere(Serie entidade)
        {
            throw new NotImplementedException();
        }

        public List<Serie> Lista()
        {
            throw new NotImplementedException();
        }

        public int ProximoId()
        {
            throw new NotImplementedException();
        }

        public Serie RetornaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
