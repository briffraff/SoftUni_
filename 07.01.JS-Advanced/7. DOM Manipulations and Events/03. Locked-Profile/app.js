function lockedProfile() {

    let buttons = [...document.querySelectorAll('.profile button')]
        .forEach(btn => btn.addEventListener('click', showHide));

    function showHide(ev) {
        let parent = ev.target.parentElement;
        
        let lockButton = parent.querySelector('input[type="radio"][value="lock"]');
        let isLocked = lockButton.checked;
        
        if (isLocked == false) {
            let hiddenInfo = parent.querySelector('.profile div');
            let isHiddenId = hiddenInfo.id.toLowerCase().includes('hidden');

            let showMoreBtn = parent.querySelector('.profile button');

            let isHidden = showMoreBtn.textContent == 'Show more' ? true : false;

            if (isHiddenId && isHidden) {
                showMoreBtn.textContent = 'Hide it';
                hiddenInfo.style.display = 'block';
            } else {
                showMoreBtn.textContent = 'Show more';
                hiddenInfo.style.display = 'none';
            }
        }
    }
}