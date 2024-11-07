document.getElementById('reviewForm').addEventListener('submit', async function (e) {
    e.preventDefault();
    const title = document.getElementById('title').value;
    const content = document.getElementById('content').value;
    const rating = document.getElementById('rating').value;

    await fetch('api/review', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ title, content, rating })
    });

    this.reset();
    loadReviews();
});

let currentPage = 1;
const pageSize = 10;

async function loadReviews() {
    const response = await fetch(`api/review?pageNumber=${currentPage}&pageSize=${pageSize}`);
    const reviews = await response.json();
    const reviewsContainer = document.getElementById('reviews');
    reviewsContainer.innerHTML = '';

    reviews.forEach(review => {
        reviewsContainer.innerHTML += `<div class="card mb-3">
            <div class="card-body">
                <h5 class="card-title">${review.title} (${review.rating})</h5>
                <p class="card-text">${review.content}</p>
                <p class="card-text"><small class="text-muted">Опубліковано: ${new Date(review.dateCreated).toLocaleString()}</small></p>
            </div>
        </div>`;
    });

    const countResponse = await fetch('api/review/count');
    const totalReviews = await countResponse.json();
    updatePagination(totalReviews);
}

function updatePagination(totalReviews) {
    const pagination = document.getElementById('pagination');
    pagination.innerHTML = '';

    const pageCount = Math.ceil(totalReviews / pageSize);
    for (let i = 1; i <= pageCount; i++) {
        const li = document.createElement('li');
        li.className = 'page-item';
        li.innerHTML = `<a class="page-link" href="#" onclick="changePage(${i})">${i}</a>`;
        pagination.appendChild(li);
    }
}

function changePage(page) {
    currentPage = page;
    loadReviews();
}

loadReviews();
