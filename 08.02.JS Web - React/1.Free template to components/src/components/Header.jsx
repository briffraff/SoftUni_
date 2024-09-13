

export default function Header() {
    return (
        <>
            <header className="grid">
                <nav className="s-12 grid background-none background-primary-hightlight">
                    <a href="index.html" className="m-12 l-3 padding-2x logo">
                        <img src="src/img/logo.svg" />
                    </a>
                    <div className="top-nav s-12 l-9">
                        <ul className="top-ul right chevron">
                            <li><a href="./template/index.html">Home</a></li>
                            <li><a href="./template/about-us.html">About Us</a></li>
                            <li><a href="./template/services.html">Services</a></li>
                            <li><a href="./template/gallery.html">Gallery</a></li>
                            <li><a href="./template/contact.html">Contact</a></li>
                        </ul>
                    </div>
                </nav>
            </header>
        </>
    )
}