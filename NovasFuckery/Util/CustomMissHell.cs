using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovasFuckery.Util {
    public abstract class CustomMissHell {
        public CustomMissHell(string name) {
            Option = new UIOption(name, "MissHell", false);
        }

        internal UIOption Option;

        public abstract void OnMiss();
    }
}