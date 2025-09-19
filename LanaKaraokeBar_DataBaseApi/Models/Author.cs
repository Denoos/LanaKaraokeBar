using System;
using System.Collections.Generic;

namespace LanaKaraokeBar_DataBaseApi.Models;

public partial class Author
{
    public int Id { get; set; }

    public string NickName { get; set; } = null!;

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
