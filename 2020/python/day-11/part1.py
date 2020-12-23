seats = [[seat for seat in row.strip()] for row in open('input.txt')]
prev = []
while seats != prev:
    prev = seats

    for rowIndex, row in enumerate(seats):
        for seatIndex, seat in enumerate(row):
            pass
