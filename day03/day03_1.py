partSum = 0
def isSymbol(c):
    if (not c.isnumeric()) and (c != ".") and c != '\n': return True
    else: return False
    
def searchLine(l1, l2, l3):
    global partSum
    onRun = 0; startIdx = 0; endIdx = 0; currentNr = ""
    for idx in range(len(l2)):
        element = l2[idx]
        if element.isnumeric() == True:
            if onRun == 0: #run starts
                startIdx = idx
                currentNr = ""
            currentNr += l2[idx]    
            onRun = 1
        else:
            if onRun == 1: # runs ends
                endIdx = idx-1; isPartNr = False
                #above left, right diagonal
                if l1 != "": isPartNr = isSymbol (l1[startIdx-1]) | isSymbol (l1[endIdx+1])
                #below left,right diagonal
                if l3 != "": isPartNr = isPartNr | isSymbol (l3[startIdx-1]) | isSymbol (l3[endIdx+1])
                #before and after same line
                isPartNr = isPartNr | isSymbol(l2[startIdx-1]) | isSymbol(l2[endIdx+1])
                #straight above and below                    
                for partIx in range(startIdx,endIdx+1):
                    if l1 != "": isPartNr = isPartNr | isSymbol(l1[partIx])
                    if l3 != "": isPartNr = isPartNr | isSymbol(l3[partIx])
                if isPartNr == True: partSum = partSum + int(currentNr)
            onRun = 0
# START
fh = open("input.txt")
line1 = fh.readline();line2 = fh.readline();line3 = fh.readline()
searchLine ("",line1,line2); searchLine (line1,line2,line3)
while True:
    line1 = line2
    line2 = line3
    line3 = fh.readline()
    searchLine (line1,line2,line3)
    if not line3: break
searchLine (line2, line3, "")
print (partSum); fh.close()
