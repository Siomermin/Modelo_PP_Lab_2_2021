using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Entidades.Botellas
    {
        public class Agua : Botella
        {
            public TipoAgua tipo;

            public Agua(string marca, double precio, int capacidad, TipoAgua tipo) : base(marca, precio, capacidad)
            {
                this.tipo = tipo;
            }
            public Agua(string marca, double precio, TipoAgua tipo) : this(marca, precio, 500, tipo)
            {

            }

            public override double Ganancia
            {
                get
                {
                    return this.precio * 0.25;
                }
            }

                protected override void ServirMedida()
                {
                    this.contenido -= this.contenido;
                }

                public override string ToString()
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("--Agua--");
                    sb.Append($"{base.ToString()}\nTipo de agua: {this.tipo}");
                    sb.AppendLine("--------");
                    return sb.ToString();
                }

                public static bool operator ==(Agua a, Agua b)
                {
                    if (a is not null && b is not null)
                    {
                        return ((Botella)a) == b && a.tipo == b.tipo;
                    }
                    return false;
                }

                public static bool operator !=(Agua a, Agua b)
                {
                    return !(a == b);
                }


                public override bool Equals(object obj)
                {
                    if (obj is not null && obj.GetType() == typeof(Agua))
                    {
                        return this == (Agua)obj;
                    }
                    return false;
                }
        }
    }


