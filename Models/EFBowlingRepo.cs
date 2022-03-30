using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlingRepo : IBowlingRepo
    {
        private BowlingDbContext _bdbc { get; set; }

        public EFBowlingRepo(BowlingDbContext temp)
        {
            _bdbc = temp;
        }

        public IQueryable<Bowler> Bowlers => _bdbc.Bowlers.Include(x => x.Team);

        public IQueryable<Team> Teams => _bdbc.Teams;

        public void AddBowler(Bowler b)
        {
            _bdbc.Add(b);
            _bdbc.SaveChanges();
        }

        public void RemoveBowler(Bowler b)
        {
            _bdbc.Remove(b);
            _bdbc.SaveChanges();
        }

        public void SaveBowler(Bowler b)
        {
            _bdbc.Update(b);
            _bdbc.SaveChanges();
        }
    }
}
