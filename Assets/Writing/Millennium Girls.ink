/********** Millennium Girls - MASTER **********/

/*Available Character Expressions:

#none = no character on screen

vanya_sad | vanya_sarcastic |vanya_happy
vanya_angry | vanya_neutral | vanya_special

halle_sad | halle_sarcastic | halle_happy
halle_angry | halle_neutral | halle_special

kay_sad | kay_sarcastic | kay_happy
kay_angry | kay_neutral | kay_special

matt_netural | matt_happy

cody

cam

#loadscene: [scene name] = how to load scene at the end of a conversation

/********** Act I, Scene 1 **********/
// EXT. Lake Massapoag - Magic Hour

===I_i_Kay_to_Vanya===
/* People with repeatable conversations need to use a variable for read-count
Create a stitch for main conversation, count that as conditional to pass
*/
{	
	- I_i_kay_to_vanya_main == 1:
	    -> I_i_Kay_to_Vanya_repeat
	- else:
	    -> I_i_kay_to_vanya_main
}
=I_i_kay_to_vanya_main
Kay: Hey. #kay_neutral
Vanya: Hey Kay, you made it! #vanya_happy
* [Yelled at by parents]
	Kay: Yeah, just had to deal with usual beratement from 'rents - #kay_angry
	Kay: I forgot to do the dishes so I'm a terrible person or some shit like that.
	Vanya: Sounds about right. #vanya_sarcastic
* [Took my time getting here]	
	Kay: Yeah, I just took my time getting here. #kay_neutral
	Kay: I forget sometimes that this town is kinda pretty.
	Vanya: Yeah but we've seen it all a million times. Does that mean it's still pretty? #vanya_sarcastic
* [Didn't want to leave]
	Kay: Yeah, not gonna lie I did not want to leave my room. #kay_neutral
	Kay: I had a pretty perfect summer malaise going on; any longer and I was going to get eaten by the couch.
	Vanya: I get that! I've been watching "American Ninja Warrior" non-stop, just 'cos there's nothing else on. #vanya_sarcastic
- Kay: Where's Halle at? #kay_neutral
Vanya: Over at the tower. Let's go see what's up. #vanya_neutral
-> DONE

=I_i_Kay_to_Vanya_repeat
Vanya: Halle's over at the lifeguard tower, let's go see what's up! #vanya_happy
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
Vanya: Hey, do you guys think we're weird?
Halle: What? #halle_sarcastic
Vanya: Like do you think other teenage girls talk about this stuff?
Halle: Well it's pretty unfair to ascribe the label 'teenage girl' to a whole gender in an age bracket. #halle_neutral
Kay: And also we're just living our particular, singular experience, which can't possibly comment on others experiences, you know? We can't be some kind of totem for "ALL TEENAGE GIRLS", obviously. #kay_neutral
Vanya: Seems legit to me. We're just weird.
Halle: Whatever. #halle_neutral
... #none
Kay: Let's get out of here. This shit's too picturesque. #kay_neutral
TODO: How to guide player out of the scene? (I.i)
-> DONE

/********** Act I, Scene 2 **********/
// EXT. Empty Shopping Plaza Parking Lot - Early Evening

===I_ii_All===
Kay: That's better. #kay_happy
Vanya: Good ol' Liberty Heights plaza. #vanya_happys
Halle: This place is about as dead as it gets. #halle_sarcastic
Kay: It sucks that the cinema closed. #kay_sad
Vanya: It sucks that the cinema got the emergency exits fixed so we couldn't sneak in during trailers. #vanya_sad
Kay: Yeah. One less thing to do around here, and the list was getting pretty short already. #kay_sarcastic
Halle: Speaking of shit to do, Vanya did you hear anything? #halle_neutral
* [Yeah! Cam texted me.]
	Vanya: Yeah! Cam texted me. #vanya_neutral
* [Yeah, Cody hit me up.]
	Vanya: Yeah! Cody hit me up. #vanya_neutral
- ... #none
Kay: Yes? AND? #kay_special
Vanya: Oh! Yeah he said there's a thing happening at Kelly Fleming's place. #vanya_happy
Halle: I forget, which one are you dating? Both their names start with "C" and teenage boys are really interchangeable. #halle_sarcastic

//Call these variables later to change context of Vanya's decision
VAR dating_cody = false
VAR dating_cam = false

* [Cody.]
	~ dating_cody = true
	Vanya: Cody. #vanya_happy
	Vanya: But I've been on dates with Cam. 
	Kay: And you've made out with both. #kay_sarcastic
	Vanya: Lots. #vanya_happy
	Halle: Are THEY aware of this overlap? #halle_sarcastic
	Vanya: Uhh, no. I WANT to tell them! But I've never found the right time. #vanya_sad
* [Cam.]
	~ dating_cam = true
	Vanya: Cam. #vanya_happy
	Vanya: But I've been on dates with Cody.
	Kay: And you've made out with both. #kay_sarcastic
	Vanya: Lots. #vanya_happy
	Halle: Are THEY aware of this overlap? #halle_sarcastic
	Vanya: Uhh, no. I WANT to tell them! But I've never found the right time. #vanya_sad
* [Yes.]
	~ dating_cody = true
	~ dating_cam = true
	Vanya: Yes. #vanya_sarcastic
	Kay: Oh. #kay_sarcastic
	Halle: Huh. #halle_sarcastic
	Vanya: It was an accident! I started hanging with Cody, then I started hanging with Cam, and I like them both a lot! #vanya_sad
	Halle: Right, that's cool, but are THEY aware of this overlap? #halle_sarcastic
	Vanya: No? #vanya_sad
	Kay: That's... not optimal. #kay_sarcastic
 	Halle: Yeah, what she said. #halle_sarcastic
- Vanya: Look, it's fine! I'll figure it out. vanya_neutral
Halle: Are they both going to the party? #halle_neutral
Vanya: Yes, why- #vanya_neutral
* [SHIT.]
	Vanya: SHIT. #vanya_angry
* [FUCK.]
	Vanya: FUCK. #vanya_angry
* [OH BOTHER.]
	Vanya: OH BOTHER. #vanya_angry
	Kay: (Did she just say what I think she did?)
	Halle: (What the hell?)
- Halle: Yeah that might become pertinent shortly. #halle_sarcastic
Halle: I guess you gotta choose a dude tonight huh? Now we HAVE to go to this party.
Kay: Oh. #kay_neutral
Halle: I mean I also am also in the mood to get drunk and cause problems in the company of people I hate. #halle_happy
Halle: Plus you two, of course. 
Halle: We can't hangout in the Liberty Plaza parking lot forever. #halle_neutral
Kay: I dare you to come up with a good reason why. #kay_sarcastic
Halle: It'll be fine! You'll be fine. We just gotta get this {~shitbucket|shittrap|steel death-trap|domestic disaster} across town to the sub-division from hell! #halle_happy
Kay: Can she hold, cap'n? #kay_sarcastic
Halle: Guess we'll find out! #halle_sarcastic
Vanya: Halle you're a really bad driver, don't blame the car. #vanya_neutral
TODO: Load the next scene! (The car mini-game)
VAR driving_fail = false
-> DONE

/********** Act II, Scene 1 **********/ 4
// EXT. Kelly Fleming's House - Front Lawn - Night

===II_i_main===
// Do I need to declare these variables earlier to make them accessible?
{
	- driving_fail == true:
	-> driving_fail
	- else: 
	-> driving_pass
}
= driving_fail
// Write out them getting to the party after walking
Halle: Well fuck. #halle_angry
Vanya: We made it! #vanya_happy
Kay: We walked three miles. #kay_angry
Halle: And my car is busted! My parents are gonna be pissed!
Kay: Who's fault is that? #kay_sarcastic
... #none
Halle: The Department of Public Works! The potholes in this town are insane! #halle_angry
-> main
= driving_pass
Vanya: We made it! #vanya_happy
Kay: Barely. #kay_sarcastic
Halle: Oh shush, we were just fine. I am an excellent driver. #halle_sarcastic
-> main

= main
Halle: So Vanya you're off to choose your beau? #halle_neutral
Vanya: I guess so? Ugh this is gonna suck no matter what huh. #vanya_sad
Kay: It might? It might also go super well and you have two life-long friendships, both of whom you got to make out with at different times. #kay_sarcastic
Kay: More likely yeah it gets awkward as fuck.
Halle: Sounds about right. #halle_sarcastic
Kay: Are you planning some kind of mischief? #kay_neutral
Halle: I'm in a mischief mood, yeah. #halle_happy
Kay: Oh goody. #kay_sarcastic
Halle: Hey everyone says I should learn how to drink BEFORE I go to college, so why not? #halle_sarcastic
Halle: What are you going to do? 
Kay: I uhh am just going to hang out. I dunno. #kay_neutral
Vanya: It'll be fun. #vanya_happy
Kay: Yeah totally, that's the word people usually use to describe these things right? #kay_sarcastic
Kay: Memories for a lifetime.
//Everyone splits off, can we animate that?

TODO: Guide player into the party, who are they controlling? (I,ii)
->DONE

/********** Act II, Scene 2 **********/ 5 
// INT. Kelly Fleming's House - Night

//Halle is now inside and can talk with people, including Kelly

//Need multiple routes for Kelly
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
* [I don't know what you could possibly be referring to.]
- Kelly: You know what I mean.
-> DONE

===II_ii_Halle_to_BeerPong===
Halle: Oh HELL yes I will take on anyone at beer pong!
Halle: Kelly, get over here! 
Kelly: What?
Halle: Be my partner! Let's fuck this shit up.
Kelly: I'm not going to say no, but I want you to know I am apprehensive about this arrangement.
Halle: And that's why no one likes you anymore.
Halle: Who wants to challenge us?!
... #none
TODO: Put some bros near the beer pong table (II,ii)
Bro: Yo.
Bro 2: Yo.
Bro: You know all the rules?
* [Hell yeah]
	Halle: Hell yeah! This ain't my first time.
* [Remind me]
	TODO: Write the rules of Beer Pong (II,ii)
VAR beer_pong_cups = 0
TODO: Load the beer pong mini-game! (II,ii)
-> DONE

===Beer_Poing_Result===
//What is the result of the Beer Pong game? Can I get the variable of how many cups you knocked over, and depending on that get an IF statement for different funny outcomes?
{
	- beer_pong_cups >= 4:
		Halle: AYYYY we won!
		Kelly: Yeah, and you drank all the beer.
		Halle: YUP. Why would I split this nectar?
	- else:
		Halle: WOW we fucked that up.
		Kelly: And yet you drank all the beer!
		Halle: YUP. Why would I waste all this nectar?
}
- Kelly: Oh goody, you're drunk.
Halle: Is this not ze poiint of partiess?
Halle: I kinda gotta drink a bunch to survive being in the same room as YOU people.
Kelly: If you hate us so much, why the hell do you feel you've got to show up and make such a big deal of being here?
... #none
Kelly: Seriously, this is like your THING.
Halle: Why yes, yes it is. Let's play another round.
TODO: Load next scene (II,ii)
-> DONE

/********** Act II, Scene 3 **********/ 7
/*
INT. Kelly's Garage
Vanya chooses her boyfriend
*/

VAR vanya_chooses_cody = false
VAR vanya_chooses_cam = false

===II_iii_Vanya===
Vanya: Well shit. Guess it's now or never. #vanya_neutral
Vanya: Cody is with his friends, the lovable lug, and Cody is over in the corner because he's a beautiful loner. #vanya_happy
Vanya: I have to choose between two super cute boys UGH THIS SUCKS. #vanya_angry
TODO: Create some kind of diegetic indicator of who she can talk to, camera pans (II,iii)
-> DONE

//Both these knots need repeat stitches, because the player will get to make a choice to continue the conversation

===II_iii_Vanya_to_Cody===
{	
	- II_iii_Vanya_to_Cody == 1:
	    -> II_iii_Vanya_to_Cody_repeat
	- else:
	    -> II_iii_Vanya_to_Cody_main
}

=II_iii_Vanya_to_Cody_main
//Cody is the SPORTY one, dense but nice
Vanya: Hey!
Cody: HEYYY V! What's up?? Me and the guys were just about break our keg-hymens, wanna join?
Vanya: That's not- nevermind, YES I wanna- WAIT.
* [*Choose Cody to be your boyfriend*]
	-> choose_cody
* [On second thought-]
	Vanya: On second thought, I'll be right back!
	Cody: No problemo!
	-> DONE

=II_iii_Vanya_to_Cody_repeat
//Make marginally different from the first, don't want characters re-introducing
Vanya: Hey!
Cody: *burp*
* [*Choose Cody to be your boyfriend*]
	-> choose_cody
* [On second thought-]
	Vanya: On second thought, I'll be right back!
	Cody: No problemo!
	-> DONE

=choose_cody
//Don't set this variable to true until the player chooses!
//Don't forget to use cody/cam_dating variables to change text in-line! Do I need this for Cody, considering what I've already written?
~ vanya_chooses_cody = true
Vanya: Cody, can I talk to you about something? #vanya_neutral
Cody: Yeah, of course! What's up? Everything okay?
Vanya: Yeah! No things are... great actually. Like with you, things are great when I'm around you. #vanya_happy
Vanya: You're brash and irresponsible and smoking hot but like also you make me feel wanted and that's cool and stuff.
Cody: Well that's cos you are wanted.
Cody: I know I'm reckless and sometimes a danger to those around me, but that's because I wanna live life right now, you know?
Cody: All this? Partying at Kelly's house, hanging with three different guys named Jay, driving my mom's minivan home at 3AM before getting up at 6AM for the gym?
Cody: That stuff ain't forever, you know?
Cody: I think of my outward masculinity as a veneer that'll fall away as I get further into college and figure out I'm gonna get a job wearing a suit or some shit like that. But for now it's really fun!
... #none
Vanya: That was really hot.
Cody: Thanks man! I'm trying. My head hurts.
TODO: Load next scene! (II,iii)
-> DONE

===II_iii_Vanya_to_Cam===
{
	- II_iii_Vanya_to_Cam == 1:
		-> II_iii_Vanya_to_Cam_repeat
	- else: 
		-> II_iii_Vanya_to_Cam_main
}

=II_iii_Vanya_to_Cam_main
//Cam is the cute sensitive one - what is their bond?
Vanya: Hey!
Cam: Hey you! Thank goodness you showed up, I was maximum three minutes from quitting life.
Vanya: Oh no! Why?
Cam: I know nOBODY at this party. This ain't exactly my crowd.
Cam: But it's really good to see your face - it's been a bit!
Vanya: Yeah, sorry about that. Things have been busy at the Gas N' Go, or with the usual suspects.
Cam: That's cool! It's summer, you wanna hang with your friends! 
Vanya: Yeah. Hey, I've got something I wanna talk to you about.
Cam: Yeah? Alright, what's up?
* [*Choose Cam to be your boyfriend*]
	-> choose_cam
* [On second thought-]
	Vanya: On second thought, I'll be right back!
	-> DONE

=II_iii_Vanya_to_Cam_repeat
Vanya: Yeah. Hey, I've got something I wanna talk to you about.
Cam: Yeah? What's up?
* [*Choose Cam to be your boyfriend*]
	-> choose_cam
* [On second thought-]
	Vanya: On second thought, I'll be right back! 
	-> DONE

= choose_cam
//Don't set this variable to true until the player chooses!
//Don't forget to use cody/cam_dating variables to change text in-line! How do I use that tool effectively? Shouldn't it just change flavor text?
~ vanya_chooses_cam = true
Vanya: Cam, do you... like me?
Cam: What do you mean?
{
	- dating_cam == true:
		Vanya: Well, we've been dating for like, a few months, but I guess I don't know where you're at on... liking me.
		Cam: Oh! I like you! Lots! Obviously! Do I not make that obvious?
		Vanya: Well, I mean it's hard to tell what you like, cos you don't like a lot of stuff.
		Cam: Just 'cos I hate the world doesn't mean I hate you!
	- else:
		Vanya: Well, we've been making out for a bit and like having moody conversations until sunrise and stuff, but we haven't been on a proper "date" yet,
		Vanya: and I was wondering if that was because you maybe didn't like me THAT way, even though I like you a... different way.
}
- Vanya: Well either way I just wanted to ask if you'd want to become a bit more... serious.
Cam: Serious?
Vanya: Yeah! Like I could come over to your place before midnight and maybe meet your parents and like we could see a movie some time? Proper date and everything?
Cam: Uhh... sure! If that's what you want! Is that what... people do?
Vanya: I think so?
Cam: How mainstream of you.
Vanya: Shut up.
TODO: Load Next Scene! (II,iii)
-> DONE

/********** Act II, Scene 4 **********/ 8 
// Kay gets freaked out


/********** Act III, Scene 1 **********/ 9 
/*
EXT. Kelly Fleming's House - Night
Kay reacting to the events of the last scene
*/

===II_iv_main===
Kay: Fuck.
Devin: Hey Matthews, you fuck yourself up too quick?
Kay: Fuck 155% OFF, Devin. 
Devin: Hey, don't freak out at me if you can't handle your shit, right?
Matt: Hey McAllister, why don't you actually give fucking off 155% a shot? 
Devin: Woah boy, singer-songwriter Matt Fenster appears! 
Devin: Your sentence structure sucks, by the way - am I fucking off 155%, or am I giving fucking off 155% of "a shot", because either way-
Kay: YOU KNOW WHAT I MEANT! #kay_angry
Kay: GET
Kay: OUT
Kay: OF
Kay: MY
Kay: FACE.
... #none
Devin: Alright, fair enough. I apologize for any sleight, you don't appear to be drunk but instead very distraught. I want none of this.
// Devin leaves, do I write stage direction into the script?
Matt: Uh. Well. I mean that worked really well.
Kay: I've known Devin since we were like two years old, he isn't bad just dumb.
-> Talk_to_matt

=Talk_to_matt
// More about her freak out, their introduction
Matt: Hey, are you okay? You in fact seem "distraught".
Kay: I, I just- yeah. Having a moment. Anxiety thing. It's a thing. It happens.
Matt: You're having a panic attack? Do you want to chill out for a bit?
Kay: Yeah, that'd be good.
// Change of scenery?
Matt: It's definitely been a couple of years since we've chatted.
Matt: I think last time we had class together was in what, 8th grade chemistry? Mr. W, who had a "bang head here" sign?
Kay: I borrowed it once.
Matt: What?
Kay: The VP was on my ass about running in the halls, so I ran into Mr. W's room and used the sign until a bunch of teachers dragged me away from it into ISS. 
Matt: Oh.
Kay: Yeah I don't know if you know, but I kinda turned into an asshole.
Matt: I mean I'd heard it, but you could've totally lied to me and I would've believed you. Way to goof that up.
Matt: I was always under the impression you weren't like an asshole, more just... surrounded by them? Oh man that's not what I mean, I mean-
Matt: I mean you fell in with a bad crowd? Oh shit I'm sounding like an after-school special.
* [You're not wrong.]
	Kay: You're not wrong.
	Kay: They may be assholes, but they're my assholes. We stick together.
	Kay: No one else around here really likes us, so we found each other and that's worked out pretty decently since.
* [You're pretty wrong.]
	Kay: You're pretty wrong.
	Kay: They're not assholes- we're not assholes. We just stick together, and don't feel like censoring ourselves so people like us.
- Matt: Fair enough. I get that. 
... #none
Matt: Are you doing okay?
Kay: Sort of. it's pretty hard to explain.
Matt: Give it a shot?
* [Drowning]
	Kay: Uhh, well if I have an attack it's like someone turned on a faucet and stuck my head in it? Like everything, every little thing, is just way too fucking much.
	Kay: You want there just to be an "off" switch for literally the entire world, but 'cos there isn't, instead you kinda end up just shutting yourself off.
* [Exhausting]
	Kay: It's pretty exhausting. My brain is always running at 100% doing like, simulations of all the bad shit that could happen. It would be impressive if it didn't suck so much.
* [Everyone is the enemy]
	Kay: It's like being the Hulk, but not green or strong or cool in any way? I'm just a raw nerve, super exposed and everyone, even if they don't know it, is jabbing at me with like, a dinner fork.
- Matt: Have you been like, checked out for this?
Kay: Nope. Then they'd give me pills and I wouldn't feel anything and that freaks me out way more. #kay_sad
Matt: I kinda assumed you were "too cool" and "detached" for this kinda stuff.
* [Just a face to put on]
	Kay: Yeah well, everyone getshanded a stereotype and I never fought mine. #kay_sad
	Kay: If no one thinks they can get a rise out of you then they won't even try. #kay_neutral
* [Well that sucks]
	Kay: Well that sucks, 'cos like we probably could've been friends BEFORE I was out here having a fucking freak out. #kay_sad
	Kay: There are a bunch of people that would probably be rad to talk to, but they all think I don't give a shit. 
	Kay: I give a shit.
// Find a much better third option
* [Nobody is]
	Kay: Literally nobody is "too cool" or "detached" for this kinda stuff. Everyone's got something.
- Kay: Fuck why am I dumping this all on you, I just met you like ten minutes ago. #kay_angry
Matt: We already knew each other! Maybe not this deep, but we knew each other.
Kay: Still, you're not exactly in my inner circle - I don't usually tell people stuff like this.
Matt: I'm glad you did. It seems like it's helping.
Kay: It is. Thanks. I...
Kay: I don't get to usually talk this stuff out.
TODO: Load the next scene! (III, i)
-> DONE

/********** Act III, Scene 2 **********/
/*
INT. Kelly's Garage
Vanya faces the consequences of her choice to which dude, because the other one comes in and learns the truth
*/

===III_ii_main===
{
	//If statement that takes you to the right knot depending on who Vanya chooses
	- vanya_chooses_cam == true:
	-> III_ii_Vanya_to_Cam
	- vanya_chooses_cody == true:
	-> III_ii_Vanya_to_Cam
}

===III_ii_Vanya_to_Cody===
//She chooses Cody, Cam comes over
//Last we left off, Cody was really honest for a second and it hurt his head
Vanya: I really appreciate you being so honest with me.
Cody: Thanks for listening! That was a new and frightening level of mental clarity.
Vanya: So like, would you like to be my... boyfriend?
Cody: Woah.
Cody: I've never identified as one of those before. Sounds good to me!
Cam: Uhh, hey?
Vanya: OH HEY CAM. WHAT ARE YOU DOING HERE?
Cam: I told you I'd be here? At the party I texted you to tell you about?
Cody: Yo! I also texted her about it and told her to come!
Vanya: Uhhh...
Cody: Oh wait-
Cam: I get the feeling there's something going on between you two?
-> III_ii_Result

===III_ii_Vanya_to_Cam===
//She chooses Cam, Cody comes over
//Last we left off, Vanya was saying she wanted to be more serious with Cam
Cam: I guess I don't get why we would become some kind of "item" going into senior year of high school?
* [Because we're good together?]
	Vanya: Well we're good together right?
	Cam: Yeah but that doesn't mean we have to be so "official", or that it's a good idea to pile on expectations and stuff.
	Vanya: "And stuff"?
	Cam: You know what I mean! 
* [Because that's what I want!]
	Vanya: Because that's what I want!
	Cam: Oh.
	Cam: I guess I'm just not sure that's what I want?
* [Because why not?]
	Vanya: Because why not? I want to be able to like, kiss you in the hall and hang out and not sneak around all the time.
	Vanya: I bet your mom would like me if she met me.
	Cam: I'm not sure my mom likes ANYONE when she first meets them.
	Vanya: Well, that's fucked up anyways, but there's still no way to know unless we try.
- Cody: Yo V!
Vanya: OH HEY CODY. WHAT ARE YOU DOING HERE?
Cody: I told you I'd be here? At the party I texted you to tell you about?
Cam: I also texted her about it and told her to come!
Vanya: Uhhh...
Cam: Oh wait-
Cody: I get the feeling I'm intruding on a moment.
-> III_ii_Result

===III_ii_Result===
{
	- dating_cody == true:
		Cody: I mean yeah, it's been a thing for a bit, we've just kept on the down-low.
		Cam: Oh. That's cool.
		Cody: Is there a problem?
		Cam: Nope! I just feel like an unknowing accomplice, 'cos me and Vanya have been hooking up for a bit.
		Cody: What the fuck?!
		Cam: If I had known I wouldn't have, man! 
		Vanya: Don't fight!! 
		... #none
		Cam: I mean I don't think we were going to? Were we?
		Cody: Nah, I wasn't gonna get physical.
		Cam: Well I greatly appreciate that because I would've lost.
		Cody: Haha yeah.
		Cody: Yeah, we weren't gonna fight cos neither of us really did anything wrong - Vanya you lied to both of us, and cheated on me.
	- dating_cam == true:
		Cody: Yeah, it's freshly official, I guess!
		Cam: Well that's problematic, cos we've been dating for 3 months.
		Cody: Woah.
		Cody: Well that's an inconvenient twist.
		Cam: Have you guys been hooking up?!
		Cody: Yeah!
		Vanya: Don't fight!!
		... #none
		Cam: I mean I don't think we were going to? Were we?
		Cody: Nah, I wasn't gonna get physical.
		Cam: Yeah, we weren't gonna fight cos neither of us really did anything wrong - Vanya you lied to both of us, and cheated on me.
	- dating_cody == true && dating_cam == true:
		Cody: I mean yeah, it's been a thing for a bit, we've just kept on the down-low.
		Cam: Well that's problematic, cos we've been dating for 3 months.
		Vanya: aww hey you remembered our anniversary- I MEAN.
		... #none
		Vanya: Shit this is awkward.
		Cam: I'd agree with that.
		Cody: Yeah. This is a thing.
		Cam: A.k.a you cheated on BOTH of us.
		Cody: That's 110% uncool.
		Cam: Under-statement.
}
- Vanya: Uhh.
Vanya: I'm sorry? Like soul-crushingly sorry?
Cam: I'm not entirely sure that suffices here, Vanya.
Cody: Yeah man I kinda gotta agree. Cam, you wanna hang out?
Cam: Yeah, that sounds chill.
{
	- dating_cody == true:
		Vanya: Cody, we'll talk later? #vanya_sad
		Cody: Yeah, for sure. Just, you gotta think about stuff first.
	- dating_cam == true:
		Vanya: Cam, we'll talk later? #vanya_sad
		Cam: Maybe. I gotta cool off for a bit.
}
//The two of them exit in some way?
Vanya: Crap. #vanya_sad
-> DONE

/********** Act III, Scene 3 - FINALE **********/
/*
EXT. Kelly's House
Halle wins beer pong, or at least "wins" in that she is rather drunk and acting like a total jerk. Kelly gets mad and kicks her out of the party. Or do I write this so that the player can either win or lose, and the game reacts thusly?
Gotta figure out some more of this scene, but from what I know it's Kelly comes out and yells at Kay, Vanya comes out and yells at both of them? This ending seems too serious now, which is kinda worrisome, maybe I should edit that a bit and make it less conflict-y.
*/

===III_iii_Int===
Kelly: GET OUT!
Halle: Woahhhh there, alright alright, I'm going.
Kelly: What the fuck is your PROBLEM, Halle? 
Kelly: I let you in because we've known each other since we were in elementary school, but you are a TOTAL bitch now!
Kelly: You don't get to show up, get drunk, break my mom's vase, and then call us "phonies" like you're some Goth version of Holden Caulfield!
Halle: I'm super totally not at all Goth.
Kelly: You wanna be way cooler than the rest of us,
Kelly: You want to be smart and aloof and go into the military instead of college and shit,
Kelly: But you just want us all to pay attention to you. 
Kelly: Get out, stay out or I'll beat you up or something. Ugh.
// Kelly leaves. Vanya comes up to Halle.
... #none
Vanya: Wow.
Halle: Right? Rad.
Vanya: I dunno, seems like you went too far this time.
Halle: I called Brooke the "c-word".
Vanya: Jeezuz, Halle. That's a bit much. What'd she do?
Halle: She was THERE. You know?
... #none
Vanya: No, I really don't.
Halle: Where's Kay at?
Vanya: She's over there, hanging out with Matt.
Halle: Let's go grab her, we're going home.
-> DONE

===III_iii_Halle_To_Kay===
Halle: Kay let's go. We're going home.
Kay: What? It's a bit early, isn't it?
Halle: What do you care? You didn't even want to come. 
Kay: Yeah, I really didn't, and we did anyways, and then I got here and had a fucking anxiety attack-
Vanya: Oh shit! Are you okay?
Kay: Yeah, I'm okay.
Matt: We've been hanging out.
Halle: You always freak out when we show up to shit like this, and have "panic attacks"-
Matt: Where there "air quotes" around that?
Halle: Yeah, there were - Kay is a total drama queen and doesn't know how to like, breathe and chill-
Matt: Woah, that's not fair, that's super uncool-
Kay: Hang on, I got this.
Kay: Halle, you NEVER listen to me or take what I want, or even what Vanya wants, into consideration,
Kay: And it's really not okay for you to just say like "breathe" or "chill out" when I say I'm having a moment.
... #none
Halle: Whatever.
Kay: Vanya, how'd your thing go?
Vanya: Badly.
Kay: Shit I'm sorry about that.
Matt: I have no idea what you're talking about, but me too.
Vanya: Thanks bro. Appreciate it.
... #none
Kay: I'm going to hang out with Matt.
Matt: I can, uhh, give her a ride home.
Vanya: (I bet you can)
Halle: I'm going home.
{
	- driving_fail == true:
		Vanya: With what car? Your ride is busted.
		Halle: I'll fucking walk.
	- driving_fail == false: 
		Vanya: You definitely shouldn't be driving.
		Vanya: And I don't have a license, so.
		Halle: Shit.
}
Vanya: Yeah, you probably shouldn't be in control of anything right now.
#none #loadscene: [the end]
-> DONE