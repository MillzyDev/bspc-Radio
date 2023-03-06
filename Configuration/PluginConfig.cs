using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace Radio.Configuration
{
    public class PluginConfig
    {
        public virtual bool Enabled { get; set; } = true;
        public virtual bool Sound3D { get; set; } = true;
        public virtual bool DisableMenuMusic { get; set; } = true;
        public virtual float Volume { get; set; } = 1f;
        public virtual float Rotation { get; set; } = 180f;
        public virtual string DefaultStation { get; set; } = "TruckersFM";
        public virtual string SelectedList { get; set; } = string.Empty;
        public virtual string SelectedStation { get; set; } = string.Empty;
        public virtual Vector2 Position { get; set; } = new Vector2(0f, -2f);
    }
}