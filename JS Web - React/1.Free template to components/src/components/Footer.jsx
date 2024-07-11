export default function Footer() {
    return (
        <>
            <footer className="grid">
                <div className="s-12 l-3 m-row-3 margin-bottom background-image" style={{ backgroundImage: 'url(src/img/img-04.jpg)' }}></div>
                <div className="s-12 m-9 l-3 padding-2x margin-bottom background-dark">
                    <h2 className="text-strong text-uppercase">Who We Are?</h2>
                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy.</p>
                </div>
                <div className="s-12 m-9 l-3 padding-2x margin-bottom background-dark">
                    <h2 className="text-strong text-uppercase">Where We Are?</h2>
                    <img className="full-img" src="/src/img/map.svg" alt="" />
                </div>
                <div className="s-12 m-9 l-3 padding-2x margin-bottom background-dark">
                    <h2 className="text-strong text-uppercase">Contact Us</h2>
                    <p><b className="text-primary margin-right-10">P</b> 0800 4521 800 50</p>
                    <p><b className="text-primary margin-right-10">M</b> <a className="text-primary-hover" href="mailto:contact@sampledomain.com">contact@sampledomain.com</a></p>
                    <p><b className="text-primary margin-right-10">M</b> <a className="text-primary-hover" href="mailto:office@sampledomain.com">office@sampledomain.com</a></p>
                </div>
                <div className="s-12 text-center margin-bottom">
                    <p className="text-size-12">Copyright 2019, Vision Design - graphic zoo</p>
                    <p className="text-size-12">All images have been purchased from Bigstock. Do not use the images in your website.</p>
                    <p><a className="text-size-12 text-primary-hover" href="http://www.myresponsee.com" title="Responsee - lightweight responsive framework">Design and coding by Responsee Team</a></p>
                </div>
            </footer>
        </>
    )
}