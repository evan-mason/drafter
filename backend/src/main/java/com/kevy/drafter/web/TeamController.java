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

import com.kevy.drafter.model.Team;
import com.kevy.drafter.model.TeamRepository;

import jakarta.validation.Valid;

@RestController
@RequestMapping("/api")
class TeamController {

    private TeamRepository teamRepository;

    public TeamController(TeamRepository teamRepository) {
        this.teamRepository = teamRepository;
    }

    @GetMapping("/teams")
    Collection<Team> teams() {
        return teamRepository.findAll();
    }

    @GetMapping("/team/{id}")
    ResponseEntity<?> getTeam(@PathVariable Long id) {
        Optional<Team> team = teamRepository.findById(id);
        return team.map(response -> ResponseEntity.ok().body(response))
                .orElse(new ResponseEntity<>(HttpStatus.NOT_FOUND));
    }

    @PostMapping("/team")
    ResponseEntity<Team> createTeam(@Valid @RequestBody Team team) throws URISyntaxException {
        Team result = teamRepository.save(team);
        return ResponseEntity.created(new URI("/api/team/" + result.getId()))
                .body(result);
    }

    @PutMapping("/team/{id}")
    ResponseEntity<Team> updateTeam(@Valid @RequestBody Team team) {
        Team result = teamRepository.save(team);
        return ResponseEntity.ok().body(result);
    }

    @DeleteMapping("/team/{id}")
    public ResponseEntity<?> deleteTeam(@PathVariable Long id) {
    	teamRepository.deleteById(id);
        return ResponseEntity.ok().build();
    }
}
