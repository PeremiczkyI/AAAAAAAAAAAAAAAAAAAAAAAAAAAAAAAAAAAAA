import React from 'react'
import { Link } from 'react-router-dom'

export default function Navbar() {
    return (
        <div>
            <nav class="navbar bg-body-tertiary">
                <form class="container-fluid justify-content-start">

                    <Link to='/'>
                        <button class="btn btn-outline-success me-2" type="button">Főoldal</button>
                    </Link>

                    <Link to='/ujjatekos'>
                        <button class="btn btn-sm btn-outline-secondary" type="button">Új játékos</button>
                    </Link>
                </form>
            </nav>
        </div>
    )
}
