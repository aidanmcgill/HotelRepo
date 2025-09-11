1. Create Hotel
POST /hotel

{
  "name": "Grand Hotel",
  "numberOfSingleRooms": 2,
  "numberOfDoubleRooms": 3,
  "numberOfDeluxRooms": 1
}
Total rooms must equal 6

2. Get Hotel
GET /hotel/{name}
Example: /hotel/Grand%20Hotel

3. Check Rooms
GET /room/{guests}/{checkIn}/{checkOut}
Example: /room/2/2024-01-15/2024-01-20

4. Create Booking
POST /booking

{
  "hotel": "Grand Hotel",
  "roomId": "26f44660-1bd5-4665-bdf7-fd1a0b259774",
  "checkInDate": "2024-01-15",
  "checkOutDate": "2024-01-20",
  "numberOfGuests": 2,
  "nameOnBooking": "John Doe"
}
5. Get Booking
GET /booking/{id}
Example: /booking/a1b2c3d4-e5f6-7890-abcd-ef1234567890

6. Clear Data (Admin)
GET /clear
Warning: Deletes all data

Room Types
Single: 1 guest

Double: 2 guests

Deluxe: e guests
