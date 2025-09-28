using System;
using System.Collections.Generic;

namespace LanaKaraokeBar_DataBaseApi.Models;

public partial class Song
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int IdGenre { get; set; }

    public int IdAuthor { get; set; }

    public virtual Author IdAuthorNavigation { get; set; } = null!;

    public virtual Genre IdGenreNavigation { get; set; } = null!;
}
