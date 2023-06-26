using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveles {
    
        public bool Estado { get; set; }
        public string Name { get; set; }

         public Niveles ()
        {
                
        }
        public Niveles (bool estado, string name)
        {
            Estado = estado;
            Name   = name;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
                     
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            Niveles other = (Niveles)obj;
            return Estado == other.Estado && Name == other.Name;
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Estado.GetHashCode();
                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                return hash;
            }
        }
        
}
