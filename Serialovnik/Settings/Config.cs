using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialovnik.Settings
{
    public class Config
    {
        private List<Serial> _serials;

        public List<Serial> Serials
        {
            get { return _serials ?? (_serials = new List<Serial>()); }
            set { _serials = value; } 
        }

        private Player _player;

        public Player Player
        {
            get { return _player ?? (_player = new Player()); }
            set { _player = value; }
        }

        public bool ShowPlayPopup { get; set; } = true;
        public int PlayPopupInterval { get; set; } = 5000;
    }

  
    
}
