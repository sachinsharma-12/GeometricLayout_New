using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometricLayout.Common;

namespace GeometricLayout.Tests.Controllers
{
    public static class GeometricLayoutControllerTestHelper
    {
        static GeometricLayoutControllerTestHelper()
        {
            LoadGeometries();
        }
        public static Dictionary<string, Dictionary<int, List<Coordinates>>> Geometries { get; set; }

        private static void LoadGeometries()
        {
            Geometries = new Dictionary<string, Dictionary<int, List<Coordinates>>>()
            {
                {
                    "a", new Dictionary<int, List<Coordinates>>()
                    {
                        {
                            1, new List<Coordinates>()
                            {
                                new Coordinates(0,6),
                                new Coordinates(0,5),
                                new Coordinates(1,5),
                            }
                        },
                        {
                            2, new List<Coordinates>()
                            {
                                new Coordinates(1,5),
                                new Coordinates(0,6),
                                new Coordinates(1,6),
                            }
                        },
                        {
                            3, new List<Coordinates>()
                            {
                                new Coordinates(2,5),
                                new Coordinates(1,5),
                                new Coordinates(1,6),
                            }
                        },
                        {
                            4, new List<Coordinates>()
                            {
                                new Coordinates(2,6),
                                new Coordinates(2,5),
                                new Coordinates(1,6),
                            }
                        },
                        {
                            5, new List<Coordinates>()
                            {
                                new Coordinates(2,6),
                                new Coordinates(2,5),
                                new Coordinates(3,5),
                            }
                        },
                        {
                            6, new List<Coordinates>()
                            {
                                new Coordinates(2,6),
                                new Coordinates(3,6),
                                new Coordinates(3,5),
                            }
                        },
                        {
                            7, new List<Coordinates>()
                            {
                                new Coordinates(3,6),
                                new Coordinates(3,5),
                                new Coordinates(4,5),
                            }
                        },
                        {
                            8, new List<Coordinates>()
                            {
                                new Coordinates(3,6),
                                new Coordinates(4,5),
                                new Coordinates(4,6),
                            }
                        },
                        {
                            9, new List<Coordinates>()
                            {
                                new Coordinates(4,6),
                                new Coordinates(4,5),
                                new Coordinates(5,5),
                            }
                        },
                        {
                            10, new List<Coordinates>()
                            {
                                new Coordinates(5,6),
                                new Coordinates(5,5),
                                new Coordinates(4,6),
                            }
                        },
                        {
                            11, new List<Coordinates>()
                            {
                                new Coordinates(5,6),
                                new Coordinates(5,5),
                                new Coordinates(6,5),
                            }
                        },
                        {
                            12, new List<Coordinates>()
                            {
                                new Coordinates(6,6),
                                new Coordinates(5,6),
                                new Coordinates(6,5),
                            }
                        },
                    }
                },
                {
                    "b", new Dictionary<int, List<Coordinates>>()
                    {
                        {
                            1, new List<Coordinates>()
                            {
                                new Coordinates(0,5),
                                new Coordinates(0,4),
                                new Coordinates(1,4),
                            }
                        },
                        {
                            2, new List<Coordinates>()
                            {
                                new Coordinates(0,5),
                                new Coordinates(1,4),
                                new Coordinates(1,5),
                            }
                        },
                        {
                            3, new List<Coordinates>()
                            {
                                new Coordinates(2,4),
                                new Coordinates(1,5),
                                new Coordinates(1,4),
                            }
                        },
                        {
                            4, new List<Coordinates>()
                            {
                                new Coordinates(2,4),
                                new Coordinates(1,5),
                                new Coordinates(2,5),
                            }
                        },
                        {
                            5, new List<Coordinates>()
                            {
                                new Coordinates(2,5),
                                new Coordinates(2,4),
                                new Coordinates(3,4),
                            }
                        },
                        {
                            6, new List<Coordinates>()
                            {
                                new Coordinates(2,5),
                                new Coordinates(3,5),
                                new Coordinates(3,4),
                            }
                        },
                        {
                            7, new List<Coordinates>()
                            {
                                new Coordinates(3,5),
                                new Coordinates(3,4),
                                new Coordinates(4,4),
                            }
                        },
                        {
                            8, new List<Coordinates>()
                            {
                                new Coordinates(3,5),
                                new Coordinates(4,4),
                                new Coordinates(4,5),
                            }
                        },
                        {
                            9, new List<Coordinates>()
                            {
                                new Coordinates(4,5),
                                new Coordinates(4,4),
                                new Coordinates(5,4),
                            }
                        },
                        {
                            10, new List<Coordinates>()
                            {
                                new Coordinates(5,4),
                                new Coordinates(5,5),
                                new Coordinates(4,5),
                            }
                        },
                        {
                            11, new List<Coordinates>()
                            {
                                new Coordinates(5,4),
                                new Coordinates(5,5),
                                new Coordinates(6,4),
                            }
                        },
                        {
                            12, new List<Coordinates>()
                            {
                                new Coordinates(5,5),
                                new Coordinates(6,5),
                                new Coordinates(6,4),
                            }
                        },

                    }
                },
                {
                    "c", new Dictionary<int, List<Coordinates>>()
                    {
                        {
                            1, new List<Coordinates>()
                            {
                                new Coordinates(0,4),
                                new Coordinates(0,3),
                                new Coordinates(1,3),
                            }
                        },
                        {
                            2, new List<Coordinates>()
                            {
                                new Coordinates(0,4),
                                new Coordinates(1,3),
                                new Coordinates(1,4),
                            }
                        },
                        {
                            3, new List<Coordinates>()
                            {
                                new Coordinates(2,3),
                                new Coordinates(1,4),
                                new Coordinates(1,3),
                            }
                        },
                        {
                            4, new List<Coordinates>()
                            {
                                new Coordinates(2,3),
                                new Coordinates(1,4),
                                new Coordinates(2,4),
                            }
                        },
                        {
                            5, new List<Coordinates>()
                            {
                                new Coordinates(2,4),
                                new Coordinates(2,3),
                                new Coordinates(3,3),
                            }
                        },
                        {
                            6, new List<Coordinates>()
                            {
                                new Coordinates(2,4),
                                new Coordinates(3,4),
                                new Coordinates(3,3),
                            }
                        },
                        {
                            7, new List<Coordinates>()
                            {
                                new Coordinates(3,4),
                                new Coordinates(3,3),
                                new Coordinates(4,3),
                            }
                        },
                        {
                            8, new List<Coordinates>()
                            {
                                new Coordinates(3,4),
                                new Coordinates(4,3),
                                new Coordinates(4,4),
                            }
                        },
                        {
                            9, new List<Coordinates>()
                            {
                                new Coordinates(4,4),
                                new Coordinates(4,3),
                                new Coordinates(5,3),
                            }
                        },
                        {
                            10, new List<Coordinates>()
                            {
                                new Coordinates(5,3),
                                new Coordinates(5,4),
                                new Coordinates(4,4),
                            }
                        },
                        {
                            11, new List<Coordinates>()
                            {
                                new Coordinates(5,3),
                                new Coordinates(5,4),
                                new Coordinates(6,3),
                            }
                        },
                        {
                            12, new List<Coordinates>()
                            {
                                new Coordinates(6,3),
                                new Coordinates(5,4),
                                new Coordinates(6,4),
                            }
                        },

                    }
                },
                {
                    "d", new Dictionary<int, List<Coordinates>>()
                    {
                        {
                            1, new List<Coordinates>()
                            {
                                new Coordinates(0,3),
                                new Coordinates(0,2),
                                new Coordinates(1,2),
                            }
                        },
                        {
                            2, new List<Coordinates>()
                            {
                                new Coordinates(0,3),
                                new Coordinates(1,2),
                                new Coordinates(1,3),
                            }
                        },
                        {
                            3, new List<Coordinates>()
                            {
                                new Coordinates(2,2),
                                new Coordinates(1,3),
                                new Coordinates(1,2),
                            }
                        },
                        {
                            4, new List<Coordinates>()
                            {
                                new Coordinates(2,2),
                                new Coordinates(1,3),
                                new Coordinates(2,3),
                            }
                        },
                        {
                            5, new List<Coordinates>()
                            {
                                new Coordinates(2,3),
                                new Coordinates(2,2),
                                new Coordinates(3,2),
                            }
                        },
                        {
                            6, new List<Coordinates>()
                            {
                                new Coordinates(2,3),
                                new Coordinates(3,3),
                                new Coordinates(3,2),
                            }
                        },
                        {
                            7, new List<Coordinates>()
                            {
                                new Coordinates(3,3),
                                new Coordinates(3,2),
                                new Coordinates(4,2),
                            }
                        },
                        {
                            8, new List<Coordinates>()
                            {
                                new Coordinates(3,3),
                                new Coordinates(4,2),
                                new Coordinates(4,3),
                            }
                        },
                        {
                            9, new List<Coordinates>()
                            {
                                new Coordinates(4,3),
                                new Coordinates(4,2),
                                new Coordinates(5,2),
                            }
                        },
                        {
                            10, new List<Coordinates>()
                            {
                                new Coordinates(5,2),
                                new Coordinates(5,3),
                                new Coordinates(4,3),
                            }
                        },
                        {
                            11, new List<Coordinates>()
                            {
                                new Coordinates(5,2),
                                new Coordinates(5,3),
                                new Coordinates(6,2),
                            }
                        },
                        {
                            12, new List<Coordinates>()
                            {
                                new Coordinates(6,2),
                                new Coordinates(5,3),
                                new Coordinates(6,3),
                            }
                        },

                    }
                },
                {
                    "e", new Dictionary<int, List<Coordinates>>()
                    {
                        {
                            1, new List<Coordinates>()
                            {
                                new Coordinates(0,2),
                                new Coordinates(0,1),
                                new Coordinates(1,1),
                            }
                        },
                        {
                            2, new List<Coordinates>()
                            {
                                new Coordinates(0,2),
                                new Coordinates(1,1),
                                new Coordinates(1,2),
                            }
                        },
                        {
                            3, new List<Coordinates>()
                            {
                                new Coordinates(2,1),
                                new Coordinates(1,2),
                                new Coordinates(1,1),
                            }
                        },
                        {
                            4, new List<Coordinates>()
                            {
                                new Coordinates(2,1),
                                new Coordinates(1,2),
                                new Coordinates(2,2),
                            }
                        },
                        {
                            5, new List<Coordinates>()
                            {
                                new Coordinates(2,2),
                                new Coordinates(2,1),
                                new Coordinates(3,1),
                            }
                        },
                        {
                            6, new List<Coordinates>()
                            {
                                new Coordinates(2,2),
                                new Coordinates(3,2),
                                new Coordinates(3,1),
                            }
                        },
                        {
                            7, new List<Coordinates>()
                            {
                                new Coordinates(3,2),
                                new Coordinates(3,1),
                                new Coordinates(4,1),
                            }
                        },
                        {
                            8, new List<Coordinates>()
                            {
                                new Coordinates(3,2),
                                new Coordinates(4,1),
                                new Coordinates(4,2),
                            }
                        },
                        {
                            9, new List<Coordinates>()
                            {
                                new Coordinates(4,2),
                                new Coordinates(4,1),
                                new Coordinates(5,1),
                            }
                        },
                        {
                            10, new List<Coordinates>()
                            {
                                new Coordinates(5,1),
                                new Coordinates(5,2),
                                new Coordinates(4,2),
                            }
                        },
                        {
                            11, new List<Coordinates>()
                            {
                                new Coordinates(5,1),
                                new Coordinates(5,2),
                                new Coordinates(6,1),
                            }
                        },
                        {
                            12, new List<Coordinates>()
                            {
                                new Coordinates(6,1),
                                new Coordinates(5,2),
                                new Coordinates(6,2),
                            }
                        },
                    }
                },
                {
                    "f", new Dictionary<int, List<Coordinates>>()
                    {
                        {
                            1, new List<Coordinates>()
                            {
                                new Coordinates(0,1),
                                new Coordinates(0,0),
                                new Coordinates(1,0),
                            }
                        },
                        {
                            2, new List<Coordinates>()
                            {
                                new Coordinates(0,1),
                                new Coordinates(1,0),
                                new Coordinates(1,1),
                            }
                        },
                        {
                            3, new List<Coordinates>()
                            {
                                new Coordinates(2,0),
                                new Coordinates(1,1),
                                new Coordinates(1,0),
                            }
                        },
                        {
                            4, new List<Coordinates>()
                            {
                                new Coordinates(2,0),
                                new Coordinates(1,1),
                                new Coordinates(2,1),
                            }
                        },
                        {
                            5, new List<Coordinates>()
                            {
                                new Coordinates(2,1),
                                new Coordinates(2,0),
                                new Coordinates(3,0),
                            }
                        },
                        {
                            6, new List<Coordinates>()
                            {
                                new Coordinates(2,1),
                                new Coordinates(3,1),
                                new Coordinates(3,0),
                            }
                        },
                        {
                            7, new List<Coordinates>()
                            {
                                new Coordinates(3,1),
                                new Coordinates(3,0),
                                new Coordinates(4,0),
                            }
                        },
                        {
                            8, new List<Coordinates>()
                            {
                                new Coordinates(3,1),
                                new Coordinates(4,0),
                                new Coordinates(4,1),
                            }
                        },
                        {
                            9, new List<Coordinates>()
                            {
                                new Coordinates(4,1),
                                new Coordinates(4,0),
                                new Coordinates(5,0),
                            }
                        },
                        {
                            10, new List<Coordinates>()
                            {
                                new Coordinates(5,0),
                                new Coordinates(5,1),
                                new Coordinates(4,1),
                            }
                        },
                        {
                            11, new List<Coordinates>()
                            {
                                new Coordinates(5,0),
                                new Coordinates(5,1),
                                new Coordinates(6,0),
                            }
                        },
                        {
                            12, new List<Coordinates>()
                            {
                                new Coordinates(6,0),
                                new Coordinates(5,1),
                                new Coordinates(6,1),
                            }
                        },
                    }
                }
            };
        }
    }
}
