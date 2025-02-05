using System;
using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;


namespace NoBoxCamp
{
    public class NoBoxCamps: Plugin<Config>
    {
       public static NoBoxCamps Instance { get; private set; }

       private Dictionary<string, int> timers = new Dictionary<string, int>();

        public override void OnEnabled()
        {
            Instance = this;
            Timing.RunCoroutine(MegaSuperLoop(NoBoxCamps.Instance.Config.HigherX, NoBoxCamps.Instance.Config.LowerX, NoBoxCamps.Instance.Config.LowerZ, NoBoxCamps.Instance.Config.HigherZ, NoBoxCamps.Instance.Config.timeinboxallowed, NoBoxCamps.Instance.Config.showhowmuchtimeisleftwhileinbox, NoBoxCamps.Instance.Config.dampersec, NoBoxCamps.Instance.Config.deathmsg));
            Exiled.Events.Handlers.Player.Verified += ver;
            base.OnEnabled();
        }
        
        
        public override void OnDisabled()
        {
            Instance = null;
           Exiled.Events.Handlers.Player.Verified -= ver;
            base.OnDisabled();
        }

        public void ver(VerifiedEventArgs ev)
        {
            if (!timers.ContainsKey(ev.Player.UserId))
            {
                timers.Add(ev.Player.UserId, NoBoxCamps.Instance.Config.timeinboxallowed);
            }
            
        }
        private IEnumerator<float> MegaSuperLoop(Double HigherX, Double LowerX, Double LowerZ, Double HigherZ, int TIMELEFT, bool showtimer, float damagepersec, string deathmsg)
        {
            
             
            
              

              
             while (true)
             {
                
                     
                 
                yield return Timing.WaitForSeconds(1f); 
                foreach(Player p in Player.List)
                {
                    
                    
                   
                    
                    if (p.Zone == ZoneType.Surface)
                    {
                        
                       
                      
                        if (p.Position.x < HigherX && p.Position.x > LowerX && p.Position.z < HigherZ && p.Position.z > LowerZ)
                        {
                               
                               if (timers[p.UserId] <= 0)
                               {
                                   if (p.Health <= damagepersec)
                                   {
                                       p.Kill(deathmsg);
                                   }
                                   p.Hurt(damagepersec);
                               }
                               else timers[p.UserId] -= 1;
                               if (showtimer)
                               {
                                   p.Broadcast(1, Convert.ToString(timers[p.UserId]));
                               }
                               
                        }
                        else 
                        {
                            
                            if (timers[p.UserId] < TIMELEFT)
                            {
                                timers[p.UserId] += 1;
                            }
                        }
                        
                        
                        
                        
                    }
                    else
                    {
                        
                       if (timers[p.UserId] < TIMELEFT)
                       {
                           
                           timers[p.UserId] += 1;
                       }
                    }
                } 
             
                
                
                 
                   
                    
                
               
 
                        
             }

            
            
        }
        
        
        
        
        
        
        
    }
}