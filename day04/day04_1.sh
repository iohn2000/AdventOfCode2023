#!/usr/bin/bash
while IFS= read -r card; do
    # Split the card into winning numbers and numbers you have
    winning_numbers=$(echo "$card" | awk -F'|' '{print $1}')
    your_numbers=$(echo "$card" | awk -F'|' '{print $2}')

    # Convert space-separated strings into arrays
    IFS=" " read -r -a winning_numbers_array <<< "$winning_numbers"
    IFS=" " read -r -a your_numbers_array <<< "$your_numbers"

    points=0
    cardPoints=0
    # Iterate over each number you have
    for number in "${your_numbers_array[@]}"; do
      # echo $number
      # Check if the number is in the winning numbers
      if [[ " ${winning_numbers_array[@]} " =~ " $number " ]]; then
	((points++))
      fi
    done
    if ((points > 0 )); then
       tmp=$((2 ** (points-1)))	    
       cardPoints=$(($cardPoints + $tmp))
    fi   
    echo "Card:$card | Winners:$points | Points: $cardPoints"
    total_points=$((total_points + cardPoints))
done < "input.txt"
echo "Total Points: $total_points"
