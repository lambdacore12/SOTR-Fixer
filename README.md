# SOTR-Fixer

This is a very simple program geared toward SRT files with a specfic guideline. It aims to go from this:

1
00:00:01.123 -> 00:00:02.456
Hello, my name is John, and welcome to my video.

To this:

1
00:00:01.123 -> 00:00:02.456
[00:00:01] John Doe [00:00:03] Hello, my name is John, and welcome to my video.


Notice how at the beginning of the subtitle, new elements were added as follows: "[start timestamp] speaker name [start timestamp]"

And of course, instead of doing that manually, it was done automatically by way of writing just one letter and a space, then working normally on the subtitle like so:

j Hello, my name is John, and welcome to my video. The program does all the replacing.


This WPF program will work as follows: One button to open an SRT file, a second button to transform it to the desired format and a third button to open the final file.

There will be another pane in which to set which letter goes with which name to perform the transformation.

Here is [an example] of the final product. (https://content.libsyn.com/p/6/a/6/6a6b41a672a1bc91/Search_Off_the_Record_-_59th_episode.pdf?c_id=149497554&cs_id=149497554&response-content-type=application%2Fpdf&Expires=1683987437&Signature=CbEwFVAKPifW9EMNRbiuFexQ~03ubnP4lPuQ9BE-XHc2iR3Uy5pNKFj8WN1WA4YXufQyUxx5-NoIwlsMN5ll7Do3YZYBbJYh9qqF5ag0lyKGfN3jKnu-nurNDS7QaJE8l3nqPxmzgdD0cEcGuKnaHEkzAziOvZkOmjWsZuAe5XXhKnhGpNsYq3-x1hLU1kTGlncxJywqJpyASRcF3da-LXpal4BZ3E2Crjh0bjdV5IHrg7EkOzEjjQSmvdyDwHgj4j9W8Kbb1VfNNlg48nyFfCpxcIpz29FnGgo6sbcy3h7mrQmRbuMncl7DorLlVToyL8bHPgrF4TguWDg1bAscBQ__&Key-Pair-Id=K1YS7LZGUP96OI)
