import React from 'react'
import { Link } from 'react-router-dom'

export default function Home() {
  return (
    <div>
        <h1>Udvozlom!</h1>

        <Link to='/jatekosok'>
            <button class="btn btn-sm btn-outline-secondary" type="button">Tovább a Játékosokra!</button>
        </Link>
    </div>
  )
}
