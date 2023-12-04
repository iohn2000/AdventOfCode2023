use strict;use warnings;
our $gameSum = 0;
open (FH, "./data.txt") or die "Cannot open file $!";
while (<FH>){  
  my $redMax = 0; my $greenMax = 0; my $blueMax = 0;
  foreach (split(/[,;]/, substr $_,(index $_,":")+1)) {
    $_ =~ s/^\s+//; 
    my @ball = split (" ", $_);
    if (($ball[1] eq "red")   && ($ball[0] > $redMax))   { $redMax = $ball[0];   }  
    if (($ball[1] eq "green") && ($ball[0] > $greenMax)) { $greenMax = $ball[0]; } 
    if (($ball[1] eq "blue")  && ($ball[0] > $blueMax))  { $blueMax = $ball[0];  } 	
  }
  $gameSum += ($redMax * $greenMax * $blueMax); 
}
print "Solution:$gameSum\n";
