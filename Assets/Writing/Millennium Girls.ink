/********** Millennium Girls - MASTER **********/

/*Available Character Expressions

#none = no character on screen

vanya_sad | vana_sarcastic |vanya_happy
vanya_angry | vanya_neutral | vanya_special

halle_sad | halle_sarcastic | halle_happy
halle_angry | halle_neutral | halle_special

kay_sad | kay_sarcastic | kay_happy
kay_angry | kay_neutral | kay_special

#loadscene: [scene name] = how to load scene at the end of a conversation

/********** Act I, Scene 1 **********/
/*
EXT. Lake Massapoag - Magic Hour
Draft 2 3.6.17
*/



->I_i_Kay_to_Vanya

===I_i_Kay_to_Vanya===
VAR visitcount = 0
{ 
- visitcount == 1:
-> TestResult
}
Kay: Hey. #kay_neutral
Vanya: Hey you made it! #vanya_happy
* [Yelled at by parents]
	Kay: Yeah, just had to deal with usual beratement from 'rents - #kay_angry
	Kay: I forgot to do the dishes so I'm a terrible person or some shit like that.
	Vanya: Sounds about right. #vanya_sarcastic
* [Took my time getting here]	
	Kay: Yeah, I just took my time getting here. #kay_neutral
	Kay: I forget sometimes that this town is kinda pretty.
	Vanya: Yeah bt we've seen it all a million times. Does that mean it's still pretty? #vanya_sarcastic
* [Didn't want to leave]
	Kay: Yeah, not gonna lie I did not want to leave my room. #kay_neutral
	Kay: I had a pretty perfect summer malaise going on; any longer and I was going to get eaten by the couch.
	Vanya: I get that! I've been watching "American Ninja Warrior" non-stop, just 'cos there's nothing else on. #vanya_sarcastic
- Kay: Where's Halle at? #kay_neutral
Vanya: Over at the tower. Let's go see what's up. #vanya_neutral
~ visitcount++
-> DONE

//Fix this
=TestResult
FUCK
->DONE

===I_i_All===
Kay: Yo. #kay_neutral
Halle: Hey K, what's up? #halle_neutral
Kay: Nothing much - What have you guys been up to? #kay_neutral
Halle: I watched "The Avengers" for the 18th time today - I'm convinced it's a film without flaws. #halle_happy
Vanya: Hell yeah. #vanya_happy
Kay: Amen. #kay_happy
Vanya: Oh yo so a guy came into the Gas N' Go today after filling up - bought a Snickers and a single lottery ticket, right? #vanya_neutral
Vanya: He won ten grand and I wanted to suplex him for it SO BAD. #vanya_angry
Halle: You're too loud to be a fugitive. #halle_sarcastic
Kay: What would you do with the cash? #kay_neutral
Kay: If you won $10,000 right now, bam, in your wallet, no questions asked.
... #none
Halle: Well first off, after taxes it's probably more like eight grand, so keep that in mind- #halle_neutral
Kay: UGH. Killjoy. #kay_angry
Vanya: Booooo. Don't bring taxes into this. I have to do them myself this year it sucks. #vanya_angry
Halle: So given EIGHT grand what would you do? #halle_sarcastic
Halle: I'd invest it - it's not much but it'd become something by the time I'm like, forty. #halle_neutral
Kay: I'd spend it instantly. #kay_neutral
Halle: I knew you'd say that- #kay_sarcastic
Kay: New phone, new clothes, laptop, bass guitar. All the essentials. #kay_happy
Vanya: I don't have a bank account, so I'd stuff it into my mattress and never tell my parents. #vanya_neutral
Halle: How the hell do you still not have a bank account? #halle_sarcastic
Vanya: Hey I don't wanna deal with that. I get paid in cash and it goes under my sleeping butt where it belongs. #vanya_neutral
... #none
Halle: Okay what about a MILLION dollars- #halle_neutral
Kay: Same thing. #kay_neutral
Vanya: Same thing. #kay_neutral
Kay: Your mattress would be very lumpy and I don't know how you'd hide that from your parents. #kay_sarcastic
Vanya: My mattress would be full of LIES. #vanya_sarcastic
Halle: You two have small dreams. #halle_sad
Kay: I dunno man, there isn't really space for big dreams nowadays. #kay_neutral
Vanya: I try not to think about that stuff. #vanya_neutral
Halle: Whatever. #halle_neutral
...
Kay: Let's get out of here. This shit's too picturesque. #kay_neutral
-> DONE

/********** Act I, Scene 2 **********/
/*
EXT. Empty Shopping Plaza Parking Lot - Early Evening
Draft 1 3.16.17
*/

===I_ii_All===
Kay: That's better.
Vanya: Good ol' Liberty Heights plaza.
Halle: This place is about as dead as it gets.
Kay: It sucks that the cinema closed.
Vanya: It sucks that the cinema got the emergency exits fixed so we couldn't sneak in during trailers.
Kay: Yeah. One less thing to do around here, and the list was getting pretty short already.
Halle: Speaking of shit to do, Vanya did you hear anything?
* [Yeah! Cam texted me.]
* [Yeah, Cody hit me up.]
- ... #none
Kay: Yes? AND?
Vanya: Oh! Yeah he said there's a thing happening at Kelly Fleming's place.
Halle: Now we're talking.
Kay: I don't like your tone.
Halle: I'm bored and feel like doing something stupid, 
-> DONE

/********** Act II, Scene 1 **********/
/*
EXT. Kelly Fleming's House - Front Lawn - Night
Draft 1 3.21.17
*/

===II_i_main===
//Variable logic for the different outcomes of the driving mini-game!
Halle: Aight so Vanya you're off to choose your beau?
Vanya: I guess so? Ugh this is gonna suck no matter what huh.
Kay: It might? It might also go super well and you have two life-long friendships, both of whom you got to make out with at different times.
Kay: More likely yeah it gets awkward as fuck.
Halle: Sounds about right.
Kay: Are you planning some kind of mischief?
Halle: I'm in a mischief mood, yeah.
Kay: Oh goody.
Halle: Hey everyone says I should learn how to drink BEFORE I go to college, so why not?
Halle: What are you going to do?
Kay: I uhh am just going to hang out. I dunno. 
Vanya: It'll be fun.
Kay: Yeah totally, that's the word people usually use to describe these things right?
Kay: Memories for a lifetime.
//Everyone splits off, can we animate that?
->DONE

/********** Act II, Scene 2 **********/
/*
INT. Kelly Fleming's House - Night
Draft 1 3.21.17
*/

//Halle is now inside and can talk with people, including Kelly?
===II_ii_Halle_to_Kelly===
Kelly: Hey, Halle!
Kelly: I uhh, don't remember inviting you?
Halle: My RSVP must have been misplaced in the mail.
Kelly: I mean you're welcome to hang out, I just didn't think this was your scene.
Halle: It usually isn't, but I heard about it through the grape-vine and couldn't resist. Not a hell of a lot happening this summer.
Kelly: You doing anything cool?
Halle: No.
... #none
Kelly: Yeah. Umm, listen. Just- just don't start anything alright? I'm just trying to have a cool party.
* [Moi?]
* [No promises?]
* [Bad Choice]
Kelly: You know what I mean.
-> DONE

/********** Act II, Scene 4 **********/
/*
EXT. Kelly Fleming's House - Night
Draft 1 3.18.17
*/

===II_iv_main===
// More about her freak out, their introduction
Matt: Have you been like, checked out for this?
Kay: Nope. Then they'd give me pills and I wouldn't feel shit and that freaks me out way more. #kay_sad
Matt: I kinda assumed you were too cool and detached to have emotions and shit.
* [Just a face to put on]
	Kay: Yeah well, everyone getshanded a stereotype and I never fought mine. #kay_sad
	Kay: If no one thinks they can get a rise out of you then they won't even try. #kay_neutral
* [Well that sucks]
	Kay: Well that sucks, 'cos like we probably could've met and been friends BEFORE I was out here having a fucking freak out. #kay_sad
	Kay: There are a bunch of people that would probably be rad to talk to, but they all think I don't give a shit. 
	Kay: I give a shit.
// Find a much better third option
* [Don't I wish]
	Kay: It'd be a shitload easier.
	Matt: Amen to that.
- Kay: Fuck why am I dumping this all on you, I just met you like ten minutes ago. #kay_angry
Matt: We met at the Lakeview Drive block party when we were like, six or something.
Kay: I don't like that you remember that.
Kay: Did we have some quirky interaction you'll never forget?
Matt: No, no, our parents introduced us and you totally bailed.
Matt: More importantly Devin, Ryan, and I were busy stealing cookies and running into the woods to get away from it all. Even at that age we knew block parties weren't cool.
Matt: My point is we all know each other, even if we don't hang out. It's a small town.
Matt: There's nobody at this party I wouldn't hang out with.
Kay: Well shit I can think of at least-
* [Three.]
* [Twenty.]
* [76%.]
	Kay: Real talk 76% of these people make me want to ramp into Quincy quarry. #kay_sarcastic
	Matt: That's fucked up, rad as the image is.
- Matt: Then why the heck are you here?
Kay: Vanya and Halle wanted to go, they're my friends so I did. It's a small town. #kay_neutral
Matt: Scrappy but loyal, girls who break shit. Can I join your gang?
Kay: Fuck off.
Kay: Also no.
->DONE