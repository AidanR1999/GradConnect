using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradConnect.Models;

namespace GradConnect.ViewModels
{
    public class FeedViewModel
    {
        public List<PostCardViewModel> PostCardFeed { get; set; }

        public FeedViewModel()
        {
            PostCardFeed = new List<PostCardViewModel>();
        }
    }
}
