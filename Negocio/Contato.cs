using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Contato
    {
        public void Insert(Modelo.Contato c)
        {
            List<Modelo.Contato> agenda = Select();
            //Validar Contato
            if (!agenda.Exists(a => a.Id == c.Id) && c.Nome != "")
            {
                Persistencia.Contato p = new Persistencia.Contato();
                p.Insert(c);
                //(new Persistencia.Contato()).Insert(c);
            }
            //Validar Contato
            
        }

        public List<Modelo.Contato> Select()
        {
            return (new Persistencia.Contato()).Select();
        }
    }
}
