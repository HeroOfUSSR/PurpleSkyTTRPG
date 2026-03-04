using PurpleSkyTTRPG.Core.Constants;
using PurpleSkyTTRPG.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.Core.Models
{
    public class LobbyCharacterNote
    {

        private LobbyCharacterNote(Guid id, Guid lobbyCharacterId, string title, string text, NoteVisibility visibility)
        {
            Id = id;
            LobbyCharacterId = lobbyCharacterId;
            Title = title;
            Text = text;
            Visibility = visibility;
        }

        public Guid Id { get; }
        public Guid LobbyCharacterId { get; }
        public string Title { get; }
        public string Text { get; }
        public NoteVisibility Visibility { get; }

        public static (LobbyCharacterNote Note, string Error) Create(Guid id, Guid lobbyCharacterId, string title, string text, NoteVisibility visibility)
        {
            var error = string.Empty;

            if (string.IsNullOrWhiteSpace(title))
            {
                error = "Title cannot be empty";
            }
            else if (title.Length > EntityConstraints.MAX_NOTETITLE_LENGTH)
            {
                error = $"Title cannot be longer than {EntityConstraints.MAX_NOTETITLE_LENGTH} characters";
            }
            else if (string.IsNullOrWhiteSpace(text))
            {
                error = "Note text cannot be empty";
            }

            var note = new LobbyCharacterNote(id, lobbyCharacterId, title, text, visibility);

            return (note, error);
        }
    }
}
