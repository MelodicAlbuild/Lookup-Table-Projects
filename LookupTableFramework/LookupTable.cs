using System;
using System.Collections.Generic;

namespace MelodicAlbuild.Utils.LookupTable.Framework
{
    public class LookupTable
    {
        private Dictionary<dynamic, dynamic> Table { get; }
        private HashSet<dynamic> ReservedKeys { get; }
    
        public LookupTable()
        {
            Table = new Dictionary<dynamic, dynamic>();
            ReservedKeys = new HashSet<dynamic>();
        }
    
        public string Get(dynamic key)
        {
            return ReservedKeys.Contains(key)
                ? null
                : Table[key];
        }
    
        public void Add(dynamic key, dynamic value)
        {
            if (ReservedKeys.Contains(key))
            {
                throw new InvalidOperationException("Key in Lookup Table is Reserved");
            }
    
            Table.Add(key, value);
            ReservedKeys.Add(key);
        }
    
        public void Remove(dynamic key)
        {
            if (!ReservedKeys.Contains(key) || !Table.ContainsKey(key))
            {
                throw new InvalidOperationException("Key in Lookup Table does not exist.");
            }
    
            Table.Remove(key);
            ReservedKeys.Remove(key);
        }
    
        public void Update(dynamic key, dynamic value)
        {
            if (!ReservedKeys.Contains(key) || !Table.ContainsKey(key))
            {
                throw new InvalidOperationException("Key in Lookup Table does not exist.");
            }
            
            Remove(key);
            Add(key, value);
        }
    }
}