use strict;
use warnings;
our $gameSum = 0;

sub parseLine {
  my $gameId = substr $_, 5, (index $_,":")-5;
  my @splits = split(/[,;]/, substr $_,(index $_,":")+1);
  my $goodGame = 1; 
  foreach (@splits) {
    $_ =~ s/^\s+//; 
    my @ball = split (" ", $_);
    if (($ball[1] eq "red" && $ball[0] > 12) ||
       ($ball[1] eq "green" && $ball[0] > 13) ||
       ($ball[1] eq "blue" && $ball[0] > 14))  
       { $goodGame = 0; last; }
  }
  if ($goodGame == 1) {
     $gameSum += $gameId;
  }
}

open (FH, "./data.txt") or die "Cannot open file $!";
while (<FH>) { parseLine($_); }
print "Solution:$gameSum\n";
