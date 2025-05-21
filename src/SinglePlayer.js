import React, { useEffect, useState } from 'react'
import axios from 'axios'
import { Link, useParams } from 'react-router-dom'

export default function SinglePlayer() {

    const params = useParams()

    const [data, setData] = useState({})

    function Get() {
        axios.get("https://darts.sulla.hu/darts/" + params.id)
            .then(function (response) {
                setData(response.data)
            })
    }

    useEffect(() => {
        Get()
    }, [])

    return (
        <div>
            <div class="card" style={{ width: "18rem" }}>
                <img src={data.image_url} class="card-img-top" alt="..." />
                <div class="card-body">
                    <h5 class="card-title">{data.name}</h5>
                    <p class="card-text">{data.birth_date}</p>
                    <p class="card-text">{data.world_ch_won}</p>
                    <Link to='/jatekosok'>
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-return-left" viewBox="0 0 16 16">
                            <path fill-rule="evenodd" d="M14.5 1.5a.5.5 0 0 1 .5.5v4.8a2.5 2.5 0 0 1-2.5 2.5H2.707l3.347 3.346a.5.5 0 0 1-.708.708l-4.2-4.2a.5.5 0 0 1 0-.708l4-4a.5.5 0 1 1 .708.708L2.707 8.3H12.5A1.5 1.5 0 0 0 14 6.8V2a.5.5 0 0 1 .5-.5" />
                        </svg>
                    </Link>
                </div>
            </div>
        </div>
    )
}
