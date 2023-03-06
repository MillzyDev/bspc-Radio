using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace Radio.Configuration
{
    public class PluginConfig
    {
        public virtual bool UseUserDefined { get; set; } = false;
        public virtual string SelectedStation { get; set; } = null;
        public virtual bool Enabled { get; set; } = false;
        public virtual float Volume { get; set; }
        public bool Sound3D { get; set; }
        //public Vector3 Position { get; set; }
    }
}