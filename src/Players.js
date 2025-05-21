import React, { useEffect, useState } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom'

export default function Players() {
    const [data, setData] = useState([])

    useEffect(() => {
        Get()
    }, [])

    function Get() {
        axios.get("https://darts.sulla.hu/darts")
            .then(function (response) {
                setData(response.data)
            })
    }

    return (
        <div style={{display: "flex", gap: "1rem"}}>
            {
                data.map(function (players) {
                    return (
                        <div class="card" style={{ width: "18rem" }}>
                            <img src={players.image_url} class="card-img-top" alt="..." />
                            <div class="card-body">
                                <h5 class="card-title">{players.name}</h5>
                                <p class="card-text">{players.birth_date}</p>
                                <p class="card-text">{players.world_ch_won}</p>
                                <Link to={`/jatekos/${players.id}`}>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-info-circle" viewBox="0 0 16 16">
                                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                        <path d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0" />
                                    </svg>
                                </Link>
                            </div>
                        </div>
                    )
                })
            }
        </div>
    )
}
