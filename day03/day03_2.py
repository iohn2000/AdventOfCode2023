gearSum = 0
def getNr(line, idx):
    i = idx; n = ""
    if not line[idx].isnumeric(): return n
    while (line[i].isnumeric()): n=n+line[i];i=i+1
    i=idx-1
    while (line[i].isnumeric()): n=line[i]+n;i=i-1    
    return n

def searchForStarGear(l):
    global gearSum
    starNrList = []
    for idx in range(len(l[1])):
        if l[1][idx] == "*":
            setSameLine = set([getNr(l[1],idx-1),getNr(l[1],idx+1)])
            if l[0] != "": setAbove = set([getNr(l[0],idx-1),getNr(l[0],idx),getNr(l[0],idx+1)])
            if l[2] != "": setBelow = set([getNr(l[2],idx-1),getNr(l[2],idx),getNr(l[2],idx+1)])
            uniqueList = setAbove|setBelow|setSameLine
            uniqueList.remove('')
            uniqueList = list(uniqueList)
            if len(uniqueList) == 2:
                gearSum = gearSum + (int(uniqueList[0]) * int(uniqueList[1]))
# START    
fh = open("input.txt")
line1 = fh.readline();line2 = fh.readline();line3 = fh.readline()
searchForStarGear (("",line1,line2)); searchForStarGear ((line1,line2,line3))
while True:
    line1 = line2
    line2 = line3
    line3 = fh.readline()
    searchForStarGear ((line1,line2,line3))
    if not line3: break
searchForStarGear ((line2,line3,""))
print (gearSum); fh.close()
