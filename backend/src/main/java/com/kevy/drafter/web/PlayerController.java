package com.kevy.drafter.web;

import java.net.URI;
import java.net.URISyntaxException;
import java.util.Collection;
import java.util.Optional;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.kevy.drafter.model.Player;
import com.kevy.drafter.model.PlayerRepository;

import jakarta.validation.Valid;

@RestController
@RequestMapping("/api")
class PlayerController {

    private PlayerRepository playerRepository;

    public PlayerController(PlayerRepository playerRepository) {
        this.playerRepository = playerRepository;
    }

    @GetMapping("/players")
    Collection<Player> players() {
        return playerRepository.findAll();
    }

    @GetMapping("/player/{id}")
    ResponseEntity<?> getPlayer(@PathVariable Long id) {
        Optional<Player> player = playerRepository.findById(id);
        return player.map(response -> ResponseEntity.ok().body(response))
                .orElse(new ResponseEntity<>(HttpStatus.NOT_FOUND));
    }

    @PostMapping("/player")
    ResponseEntity<Player> createPlayer(@Valid @RequestBody Player player) throws URISyntaxException {
        Player result = playerRepository.save(player);
        return ResponseEntity.created(new URI("/api/player/" + result.getId()))
                .body(result);
    }

    @PutMapping("/player/{id}")
    ResponseEntity<Player> updatePlayer(@Valid @RequestBody Player player) {
        Player result = playerRepository.save(player);
        return ResponseEntity.ok().body(result);
    }

    @DeleteMapping("/player/{id}")
    public ResponseEntity<?> deletePlayer(@PathVariable Long id) {
    	playerRepository.deleteById(id);
        return ResponseEntity.ok().build();
    }
}