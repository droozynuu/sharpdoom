/*
 * Creato da SharpDevelop.
 * Utente: Mattias Cibien
 * Data: 22/05/2009
 * Ora: 21.49
 * 
 */

/// <summary>
/// Player states.
/// </summary>
using Doomed;
enum PlayerState
{
    // Playing or camping.
    LIVE,
    // Dead on the ground, view follows killer.
    DEAD,
    // Ready to restart/respawn???
    REBORN		

};

/// <summary>
/// Player internal flags, for cheats and debug.
/// </summary>
enum Cheat
{
    // No clipping, walk through barriers.
    NOCLIP		= 1,
    // No damage, no health loss.
    GODMODE		= 2,
    // Not really a cheat, just a debug aid.
    NOMOMENTUM	= 4

};

///
/// Extended player object info: player_t
///
struct Player
{
    MapObject	mo;
    PlayerState	playerstate;
    //ticcmd_t		cmd;

    // Determine POV,
    //  including viewpoint bobbing during movement.
    // Focal origin above r.z
    float		viewz;
    // Base height above floor for viewz.
    float		viewheight;
    // Bob/squat speed.
    float         	deltaviewheight;
    // bounded/scaled total momentum.
    float         	bob;	

    // This is only used between levels,
    // mo->health is used during levels.
    int			health;	
    int			armorpoints;
    // Armor type is 0-2.
    int			armortype;	
    /*
    // Power ups. invinc and invis are tic counters.
    int			powers[NUMPOWERS]
    bool		cards[NUMCARDS];
    bool		backpack;
    
    // Frags, kills of other players.
    int			frags[MAXPLAYERS];
    weapontype_t	readyweapon;
    
    // Is wp_nochange if not changing.
    weapontype_t	pendingweapon;

    bool		weaponowned[NUMWEAPONS];
    int			ammo[NUMAMMO];
    int			maxammo[NUMAMMO];
    */
    // True if button down last tic.
    int			attackdown;
    int			usedown;

    // Bit flags, for cheats and debug.
    // See cheat_t, above.
    int			cheats;		

    // Refired shots are less accurate.
    int			refire;		

     // For intermission stats.
    int			killcount;
    int			itemcount;
    int			secretcount;

    // Hint messages.
    string		message;	
    
    // For screen flashing (red or bright).
    int			damagecount;
    int			bonuscount;

    // Who did damage (NULL for floors/ceilings).
    MapObject		attacker;
    
    // So gun flashes light up areas.
    int			extralight;

    // Current PLAYPAL, ???
    //  can be set to REDCOLORMAP for pain, etc.
    int			fixedcolormap;

    // Player skin colorshift,
    //  0-3 for which color to draw player.
    int			colormap;	

    // Overlay view sprites (gun, etc).
    //pspdef_t		psprites[NUMPSPRITES];

    // True if secret level has been done.
    bool		didsecret;	

}


//
// INTERMISSION
// Structure passed e.g. to WI_Start(wb)
//
struct WbPlayerStruct
{
    bool	IiInGame;	// whether the player is in game
    
    // Player stats, kills, collected items etc.
    int		Skills;
    int		Sitems;
    int		Ssecret;
    int		Stime; 
    int[]	Frags;
    int		Score;	// current score on entry, modified on return
  
};

struct WbStartStruct
{
    int		epsd;	// episode # (0-2)

    // if true, splash the secret level
    bool	didsecret;
    
    // previous and next levels, origin 0
    int		last;
    int		next;	
    
    int		maxkills;
    int		maxitems;
    int		maxsecret;
    int		maxfrags;

    // the par time
    int		partime;
    
    // index of this player in game
    int		pnum;	

    //WbPlayerStruct	plyr[MAXPLAYERS];

};
