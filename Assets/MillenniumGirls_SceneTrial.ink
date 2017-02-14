//Millennium Girls, trial scene

VAR want_to_go = false

-> Begin

===Begin===
Halle: Hey so what the fuck are we doing tonight?
Vanya: I just got a text from Cody, there's a thing happening at Brooke's.
Kay: And we would want to be there why?
Halle: I forget, which one are you dating - Cody or Caleb?
Vanya: Yes.
Kay: Oh. Well then.
Halle: So what are we gonna do?
    * [Go to the party]
        ~ want_to_go = true
        -> Choice1
    * [Ugh, no way]
        ~ want_to_go = false
        -> Choice1
    * [I mean, what choice do we have.]
        ~ want_to_go = false
        There's nothing to do around here anyways.
        -> Choice1
=Choice1
{
- want_to_go:
Kay: Why not.
Halle: Yeah why not.
    * Go to the party -> theparty
- else:
Kay: I dunno man, going to a Brooke party when you have imminent romantic problems sounds like a poor decision.
Halle: Tally ho, good chap.
Vanya: Well fuck you guys, I have to go. I gotta tell them what's going on.
Kay: My what explicit characterization of you.
Halle: Hi Connor.
    * Go to the party -> theparty
}
    
===theparty===
WELLCOME TO THE PARTAYYYYYY
Vanya: Well shit, I'm going to have to go choose which pretty boy I want to cuddle with forever.
    * Cody 
        <>'s the sensitive one. He'll hold me tight and listen to Bon Iver with me.
    * Caleb
        <> is really really good at making out. Not sure what else though. And that's just FINE.
-> DONE