// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Utilities.Constants
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using Rift.Frontend.Models;

namespace Rift.Frontend.Utilities
{
  public static class Constants
  {
    public static readonly Changelog CHANGELOG;

    static Constants()
    {
      Changelog changelog = new Changelog();
      changelog.Description = "Chapter 2 support is here, jump in now!";
      ref Changelog local = ref changelog;
      ChangelogSection[] changelogSectionArray = new ChangelogSection[3];
      ChangelogSection changelogSection1 = new ChangelogSection();
      changelogSection1.Title = "Chapter 2 support";
      // ISSUE: explicit reference operation
      (^ref changelogSection1).Changes = new ChangelogChange[4]
      {
        new ChangelogChange()
        {
          Summary = "Chapter 2 support is here!",
          Description = "Please note that support only goes up to Chapter 2, Season 5. Builds any newer than that will not work. Hop in now and experience these events again:"
        },
        new ChangelogChange()
        {
          Summary = "Travis Scott's Astronomical",
          Description = "on Fortnite 12.41"
        },
        new ChangelogChange()
        {
          Summary = "The Device",
          Description = "on Fortnite 12.61"
        },
        new ChangelogChange()
        {
          Summary = "The Devourer of Worlds",
          Description = "on Fortnite 14.60"
        }
      };
      changelogSectionArray[0] = changelogSection1;
      ChangelogSection changelogSection2 = new ChangelogSection();
      changelogSection2.Title = "Fixes and improvements";
      // ISSUE: explicit reference operation
      (^ref changelogSection2).Changes = new ChangelogChange[3]
      {
        new ChangelogChange()
        {
          Summary = "Fixed weapon sounds on most builds.",
          Description = "Weapon sounds will now work up to Chapter 2, Season 5. Pew pew."
        },
        new ChangelogChange()
        {
          Summary = "We split the SpawnWeapon command into two commands.",
          Description = "To give yourself a weapon, \"use cheatscript GiveItem <WID>\". To spawn a pickup, \"use cheatscript SpawnItem <WID>\"."
        },
        new ChangelogChange()
        {
          Summary = "You can now exit vehicles.",
          Description = "Thank god."
        }
      };
      changelogSectionArray[1] = changelogSection2;
      ChangelogSection changelogSection3 = new ChangelogSection();
      changelogSection3.Title = "Known issues";
      // ISSUE: explicit reference operation
      (^ref changelogSection3).Changes = new ChangelogChange[3]
      {
        new ChangelogChange()
        {
          Summary = "Editing has been disabled on Chapter 2, Season 3 and newer due to a crash bug.",
          Description = "We're looking into the issue and hope to get it resolved ASAP."
        },
        new ChangelogChange()
        {
          Summary = "The water level is at its highest, regardless of build on Chapter 2, Season 3.",
          Description = "Due to missing POI issues, we've had to keep the water level at its highest for the time being."
        },
        new ChangelogChange()
        {
          Summary = "You can't pick up pickups in Chapter 2 and above.",
          Description = "We're looking into the issue and hope to get it resolved ASAP."
        }
      };
      changelogSectionArray[2] = changelogSection3;
      local.Sections = changelogSectionArray;
      Constants.CHANGELOG = changelog;
    }
  }
}
