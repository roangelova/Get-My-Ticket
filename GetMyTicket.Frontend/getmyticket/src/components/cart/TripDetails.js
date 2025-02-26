import munich from '../../assets/images/destinations/munich.jpg'

function TripDetails({ trip }) {
    if (!trip) return <h2>No trip</h2>;

    let tripDurationinInMins = new Date(trip.endTime) - new Date(trip.startTime);
    const totalMinutes = Math.floor(tripDurationinInMins / (1000 * 60));
    const hours = Math.floor(totalMinutes / 60);
    const minutes = totalMinutes % 60;

    return (
        <div className="trip-details">
            <img src={munich} alt="Trip" className="trip-details__image" />
            <div className="trip-details__data">
                <h3>{trip.startCityName} → {trip.endCityName}</h3>
                <p><strong>Departure time:</strong> {new Date(trip.startTime).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit', hour12: false })}</p>
                <p><strong>Travel time:</strong> {hours} hours and {minutes} minutes</p>
                <p><strong>Price:</strong> {trip.currency} {trip.price}</p>
                <p><strong>Number of seats:</strong> 1</p>
                <p><strong>Provider:</strong> {trip.transportationProviderName}</p>
            </div>
        </div>
    );
}

export default TripDetails;