// JavaScript functions for scroll handling
globalThis.addScrollListener = (dotNetRef) => {
    const handleScroll = () => dotNetRef.invokeMethodAsync('OnScroll', window.scrollY);
    window.addEventListener('scroll', handleScroll);
};

globalThis.scrollToSection = (sectionId) => {
    const element = document.getElementById(sectionId);
    if (element) {
        const offset = 80;
        const elementPosition = element.getBoundingClientRect().top;
        const offsetPosition = elementPosition + window.pageYOffset - offset;
        window.scrollTo({ top: offsetPosition, behavior: 'smooth' });
    }
};

// Animate carousel sliding effect
globalThis.animateCarouselSlide = function (gridId, direction) {
    const grid = document.getElementById(gridId);
    if (!grid) return;
    grid.style.transition = 'transform 0.4s cubic-bezier(0.77,0,0.175,1)';
    grid.style.transform = `translateX(${direction * 60}px)`;
    setTimeout(() => {
        grid.style.transform = 'translateX(0)';
    }, 400);
};