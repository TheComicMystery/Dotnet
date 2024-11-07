async function loadEvents() {
    try {
        const response = await fetch('/api/events');
        const events = await response.json();
        
        const eventsList = document.getElementById('eventsList');
        eventsList.innerHTML = events.map(event => `
            <li>
                <h3>${event.name}</h3>
                <p>${new Date(event.date).toLocaleDateString()} - ${event.location}</p>
                <p>${event.description || "No description available"}</p>
            </li>
        `).join('');
    } catch (error) {
        console.error("Error loading events:", error);
    }
}

document.addEventListener('DOMContentLoaded', loadEvents);
