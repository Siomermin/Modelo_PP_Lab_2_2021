using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Botellas;

        namespace Entidades.Establecimiento
        {
            public class Bar
            {
                private List<Botella> botellas;
                private int capacidadMaximaBotellas;
                private string nombre;
                private double recaudacion;

                public Bar()
                {
                    botellas = new List<Botella>();
                    
                }
                public Bar(int capacidad) :this()
                {
                    this.capacidadMaximaBotellas = capacidad;
                }
                public Bar(int capacidad, string nombre) :this(capacidad)
                {
                    this.nombre = nombre;
                }

                public string MostrarBar
                {
                    get
                    {
                        return this.Mostrar();
                    }
                }

                public List<Botella> Botellas
                {
                    get
                    {
                        return this.botellas;
                    }
                }

                private string Mostrar()
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"Nombre: {this.nombre} - Capacidad Botellas: {this.capacidadMaximaBotellas} - Recaudacion: {this.recaudacion}");
                    foreach (Botella item in this.Botellas)
                    {
                        sb.Append(item.ToString());
                    }

                    return sb.ToString();
                }

                public void OrdenarBotellas(Ordenamiento o)
                {
                    switch(o)
                    {
                        case Ordenamiento.Ganancia:
                            this.Botellas.Sort(OrdenarPorGanancia);
                            break;

                        case Ordenamiento.Marca:
                            this.Botellas.Sort(Bar.OrdenarPorMarca);
                            break;

                        case Ordenamiento.PorcentajeContenido:
                            this.Botellas.Sort(Bar.OrdenarPorContenido);
                            break;
                    }
                }

                private static int OrdenarPorContenido(Botella a, Botella b)
                {
                    int retorno = 0;

                    if (a.PorcentajeContenido > b.PorcentajeContenido)
                    {
                        retorno = 1;
                    }
                    else if (a.PorcentajeContenido < b.PorcentajeContenido)
                    {
                        retorno = -1;
                    }

                    return retorno;
                }

                private int OrdenarPorGanancia(Botella a, Botella b)
                {
                    int retorno = 0;

                    if (a.Ganancia > b.Ganancia)
                    {
                        retorno = 1;
                    }
                    else if (a.Ganancia < b.Ganancia)
                    {
                        retorno = -1;
                    }

                    return retorno;
                }

                private static int OrdenarPorMarca(Botella a, Botella b)
                {
                    return String.Compare((string)a, (string)b);
                }

                public static explicit operator Double(Bar b)
                {
            /*
                    if (b is not null)
                    {
                        foreach (Botella item in b.Botellas)
                        {
                            b.recaudacion += item.Ganancia;
                        }
                    }
                    */
                    return b.recaudacion;
                }

                public static bool operator ==(Bar a, Botella b)
                {
                    if (a is not null && b is not null)
                    {
                        foreach (Botella item in a.Botellas)
                        {
                            if (item.Equals(b))
                            {
                                return true;
                            }
                        }
                    }

                    return false;
                }

                public static bool operator !=(Bar a, Botella b)
                {
                    return !(a == b);
                }

                public static Bar operator +(Bar a, Botella b)
                {
                    if (a.Botellas.Count < a.capacidadMaximaBotellas && a != b)
                    {
                        a.Botellas.Add(b);
                    }

                    return a;
                }

                public static Bar operator +(Bar a, double g)
                {
                    a.recaudacion += g;
                    return a;
                }

                public static Bar operator -(Bar a, Botella b)
                {
                    if (a == b)
                    {
                        b--;
                        a += b.Ganancia;
                        if (b.PorcentajeContenido == 0)
                        {
                            a.Botellas.Remove(b);
                        }
                    }
                    return a;
                }
            }
        }
  
